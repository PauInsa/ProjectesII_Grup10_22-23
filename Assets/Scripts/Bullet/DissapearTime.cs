using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearTime : MonoBehaviour
{
    public float despawnTime;
    public Rigidbody2D rb;
    public Pool pool;
    float currentTime;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentTime = despawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
            pool.DeSpawn(rb);
    }

    public void SetPool(Pool newPool)
    {
        pool = newPool;
    }
}
