using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearTime : MonoBehaviour
{
    public float despawnTime;
    public Rigidbody2D rb;
    public PoolRb pool;
    float currentTime;

    void OnEnable()
    {
        currentTime = despawnTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
            pool.DeSpawn(rb);
    }

    public void SetPool(PoolRb newPool)
    {
        pool = newPool;
    }
}
