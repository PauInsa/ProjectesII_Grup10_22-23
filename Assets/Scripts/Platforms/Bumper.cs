using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float Force;
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Gun"))
        {
            Vector2 direction = this.gameObject.transform.position - collision.gameObject.GetComponent<Transform>().position;
            direction.Normalize();

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (direction * Force);

            animator.SetTrigger("Hit");
        }

    }
}
