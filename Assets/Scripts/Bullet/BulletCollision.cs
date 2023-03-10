using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public BoxCollider2D col;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Collide();
        }

        if (collision.CompareTag("Enemy"))
        {
            Collide();
            HP hp = collision.GetComponent<HP>();
            if (hp != null)
            {
                hp.DamageReceived(this.GetComponent<BulletStats>().damage);
            }
        }
    }
    private void Collide()
    {
        rb.simulated = false;
        col.enabled = false;
        anim.SetTrigger("Impact");
        Invoke("ClearBullet", 0.5f);
    }
    private void ClearBullet()
    {
        Destroy(this.gameObject);
    }
}
