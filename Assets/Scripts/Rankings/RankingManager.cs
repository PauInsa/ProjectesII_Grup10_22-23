using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankingManager : MonoBehaviour
{
    public float[] timeData;
    public int[] shotsData;

    public GameObject timeRecord;
    public GameObject shotRecord;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI shotText;

    // Start is called before the first frame update
    void Start()
    {
        //ResetRanking();

        timeRecord.SetActive(false);
        shotRecord.SetActive(false);

        RankingData data = SaveData.LoadRanking();

        timeData = data.time;
        shotsData = data.shots;
    }

    void ResetRanking()
    {
        timeData = new float[100];
        shotsData = new int[100];

        for (int i = 0; i < 100; i++)
        {
            timeData[i] = 1000;
            shotsData[i] = 1000;
        }

        SaveData.Save(timeData, shotsData);
    }

    public void EndLevel(int level, float time, int shots)
    {
        if (timeData[level] > time)
        {
            timeData[level] = time;
            timeRecord.SetActive(true);
        }

        if (shotsData[level] > shots)
        {
            shotsData[level] = shots;
            shotRecord.SetActive(true);
        }

        timeText.text = (time + "/\n" + timeData[level]);
        shotText.text = (shots + "/\n" + shotsData[level]);

        SaveLevelData();
    }

    void SaveLevelData()
    {
        SaveData.Save(timeData, shotsData);
    }
}
