using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRate;
    float deltaTimeAttack = 0.0f;

    public GameObject attackTarget;

    EnemyMovement mov;

    // Start is called before the first frame update
    void Start()
    {
        mov = this.GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.left, 0.5f, LayerMask.GetMask("Humans")))
        {
            mov.stop = true;
            Attack();
        }
        else
            mov.stop = false;
    }

    void Attack()
    {
        if (Time.time > deltaTimeAttack)
        {
            mov.Jump();
            deltaTimeAttack = Time.time + attackRate;

            GameObject target = attackTarget.GetComponent<RangeCollision>().objective;
            target.GetComponent<HP>().DamageReceived(this.GetComponent<EnemyStats>().damage);
        }
    }
}
