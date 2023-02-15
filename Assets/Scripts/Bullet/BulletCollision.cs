using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            HP hp = collision.GetComponent<HP>();
            if (hp != null)
            {
                hp.DamageReceived(this.GetComponent<BulletStats>().damage);
            }
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
