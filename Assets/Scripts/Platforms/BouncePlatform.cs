using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    public float Force;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Gun"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * Force);
        }

    }
}
