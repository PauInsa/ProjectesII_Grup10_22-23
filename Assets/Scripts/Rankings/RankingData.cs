using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RankingData
{
    public float[] time;
    public int[] shots;

    public RankingData(float[] t, int[] s)
    {
        time = new float[100];
        shots = new int[100];

        time = t;
        shots = s;
    }
}
