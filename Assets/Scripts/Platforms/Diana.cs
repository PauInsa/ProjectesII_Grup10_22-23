using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D()
    {
        Destroy(door.gameObject);
        Destroy(this.gameObject);
    }
}
