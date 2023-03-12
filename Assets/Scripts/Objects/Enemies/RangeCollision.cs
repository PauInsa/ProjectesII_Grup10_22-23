using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCollision : MonoBehaviour
{
    public GameObject objective;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Human"))
            objective = collision.gameObject;
        else
            objective = null;
    }
}
