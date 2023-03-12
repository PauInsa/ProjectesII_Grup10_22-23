using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp;
    public Animator animator;
    public Collider2D collider;
    public Rigidbody2D rb;
    public ParticleSystem blood;
    public DissapearTimeWithStart dissapear;

    public bool isDead;

    //public AudioSource audioSource;

    void Start()
    {
        isDead = false;
    }

    private void Update()
    {

    }
    public void DamageReceived(int damage)
    {
        animator.SetTrigger("isHurt");
        blood.Play();


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
        isDead = true;
        dissapear.StartTimer();
        animator.SetBool("isDead", isDead);
        Invoke("Disable", 0.5f);
    }

    void Disable()
    {
        if(rb != null)
            rb.simulated = false;
        collider.enabled = false;
    }
}
