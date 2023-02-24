using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public Rigidbody2D rb;
    public Transform enemyTransform;

    public float jumpMagnitude;

    public bool stop;

    public bool grounded;

    void Start()
    {
        stop = false;
        grounded = false;
    }

    void Update()
    {
        grounded = Physics2D.Raycast(enemyTransform.position, Vector2.down, 0.8f, LayerMask.GetMask("Wall"));

        if (stop == false)
            Move();
    }

    public void Jump()
    {
        if (grounded)
            rb.AddForce(Vector2.up * jumpMagnitude);
    }
    private void Move()
    {
        rb.velocity = new Vector2(-2, rb.velocity.y);
    }
}
