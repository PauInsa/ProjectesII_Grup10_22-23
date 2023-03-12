using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObj : MonoBehaviour
{
    public GameObject prefab;
    List<GameObject> objects = new List<GameObject>();

    public GameObject Spawn()
    {
        if (objects.Count == 0)
            return Instantiate(prefab).GetComponent<GameObject>();

        GameObject obj = objects[0];
        obj.gameObject.SetActive(true);
        objects.RemoveAt(0);
        return obj;
    }

    public void DeSpawn(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        objects.Add(obj);
    }
}
