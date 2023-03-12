using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public BoxCollider2D col;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("MapLimit"))
        {
            Collide();
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Human"))
        {
            Collide();
            HP hp = collision.gameObject.GetComponent<HP>();
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
