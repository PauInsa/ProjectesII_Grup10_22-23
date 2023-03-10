using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp;
    Animator animator;
    Collider2D collider;
    Rigidbody2D rb;
    bool isHurt;
    //public AudioSource audioSource;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        collider = this.GetComponent<Collider2D>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }
    public void DamageReceived(int damage)
    {
        animator.Play("Hurt");
        
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    //public void HurtSound()
    //{
    //    audioSource.Play();
    //}


    void Die()
    {
        animator.SetBool("isDead", true);
        rb.simulated = false;
        collider.enabled = false;
    }
}
