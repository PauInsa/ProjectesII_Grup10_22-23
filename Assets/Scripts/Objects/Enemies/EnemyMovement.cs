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

    void Start()
    {
        stop = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Jump();

        if (stop == false)
            Move();
    }

    public void Jump()
    {
        bool grounded = Physics2D.Raycast(enemyTransform.position, Vector2.down, 0.1f);

        if (grounded)
            rb.AddForce(Vector2.up * jumpMagnitude);
    }
    private void Move()
    {
        rb.velocity = new Vector2(-2, rb.velocity.y);
    }
}
