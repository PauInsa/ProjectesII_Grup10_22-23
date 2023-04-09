using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolRb : MonoBehaviour
{
    public GameObject prefab;
    List<Rigidbody2D> objects = new List<Rigidbody2D>();

    public Rigidbody2D Spawn()
    {
        if(objects.Count == 0)
            return Instantiate(prefab).GetComponent<Rigidbody2D>();

        Rigidbody2D rb = objects[0];
        rb.gameObject.SetActive(true);
        objects.RemoveAt(0);
        return rb;
    }

    public void DeSpawn(Rigidbody2D rb)
    {
        rb.gameObject.SetActive(false);
        objects.Add(rb);
    }
}
