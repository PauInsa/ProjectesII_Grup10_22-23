using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmo : MonoBehaviour
{
    public int bonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            collision.gameObject.GetComponent<Shoot>().maxAmmo += bonus;
            Destroy(this.gameObject);
        }
    }
}
