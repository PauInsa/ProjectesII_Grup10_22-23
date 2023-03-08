using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp;
    Animator animator;
    bool isHurt;
    //public AudioSource audioSource;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isHurt", false);
    }
    public void DamageReceived(int damage)
    {
        animator.SetBool("isHurt", true);
        
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
        //Destroy(gameObject);
    }
}
