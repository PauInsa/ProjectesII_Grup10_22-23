using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> enemies;

    public bool ended;

    float deltaTime;
    public float timeBetweenGroups;
    public float timeBetweenSpawns;
    public int waves;

    int lastSpawn;
    int leftToSpawn;

    bool ableToSpawn;
    bool spawning;
    bool noEnemiesAlive;

    // Start is called before the first frame update
    void Start()
    {
        ableToSpawn = true;
        ended = false;
        deltaTime = Time.time + timeBetweenGroups;
        lastSpawn = 0;
        spawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].GetComponent<HP>().hp == 0)
                enemies.RemoveAt(i);
        }

        if (enemies.Count == 0)
            noEnemiesAlive = true;
        else
            noEnemiesAlive = false;

        if (lastSpawn == waves + 1)
            ableToSpawn = false;

        if (spawning && ableToSpawn)
        {
            if (Time.time > deltaTime)
                Spawn();

            if (leftToSpawn == 0)
            {
                spawning = false;
                deltaTime = Time.time + timeBetweenGroups;
            }
        }
        else
        {
            if (Time.time > deltaTime)
            {
                lastSpawn++;
                leftToSpawn = lastSpawn;
                spawning = true;
            }
        }

        if (!ableToSpawn && noEnemiesAlive)
        {
            ended = true;
        }
    }

    public void Spawn()
    {
        GameObject obj = Instantiate(prefab);
        enemies.Add(obj);

        //obj.GetComponent<DissapearTimeWithStart>().SetPool(pool);
        obj.transform.position = this.transform.position;

        leftToSpawn--;
        deltaTime = Time.time + timeBetweenSpawns;
    }
}
