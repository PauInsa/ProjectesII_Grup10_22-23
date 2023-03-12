using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public GameObject kid;
    public List<GameObject> humans;
    public int startKids;
    int LeftToSpawn;

    public bool ended;

    public float y;
    public float startPos;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        ended = false;
        LeftToSpawn = startKids;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<humans.Count; i++)
        {
            if (humans[i].GetComponent<HP>().hp == 0)
                humans.RemoveAt(i);
        }

        if (LeftToSpawn > 0)
        {
            SpawnKid();
            LeftToSpawn--;
        }

        if (humans.Count == 0)
            ended = true;
    }

    public void SetPositions()
    {
        for(int i = 0; i<humans.Count; i++)
        {
            humans[i].transform.position = new Vector2(startPos + distance * i, y);
        }
    }

    public void SpawnKid()
    {
        GameObject newKid = Instantiate(kid);
        humans.Add(newKid);

        SetPositions();
    }
}
