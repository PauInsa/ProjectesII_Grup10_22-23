using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float AttackRate;
    float deltaTimeAttack = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        if (Physics2D.Raycast(this.transform.position, Vector2.left, 0.5f, LayerMask.GetMask("Humans")))
        {
            Attack();
        }
    }

    void Attack()
    {
        EnemyMovement mov = this.GetComponent<EnemyMovement>();

        mov.stop = true;

        if (Time.time > deltaTimeAttack)
        {
            mov.Jump();
            deltaTimeAttack = Time.time + AttackRate;
        }
    }
}
