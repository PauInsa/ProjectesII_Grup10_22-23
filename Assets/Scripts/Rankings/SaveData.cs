using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void Save(float[] t, int[] s)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "ranking.dat";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        RankingData data = new RankingData(t,s);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static RankingData LoadRanking()
    {
        string path = Application.persistentDataPath + "ranking.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Open);

        RankingData data = formatter.Deserialize(fileStream) as RankingData;
        fileStream.Close();

        return data;
    }
}
