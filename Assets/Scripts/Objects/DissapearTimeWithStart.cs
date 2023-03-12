using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearTimeWithStart : MonoBehaviour
{
    bool started;
    public float despawnTime;
    //public GameObject obj;
    //public PoolObj pool;
    float deltaTime;

    private void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (started && Time.time > deltaTime)
            Destroy(this.gameObject);
            //pool.DeSpawn(obj);
    }

    //public void SetPool(PoolObj newPool)
    //{
    //    pool = newPool;
    //}

    public void StartTimer()
    {
        deltaTime = Time.time + despawnTime;
        started = true;
    }
}
