using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletCollider : MonoBehaviour
{
	public AudioSource audioSource;
	public int damage;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Bloques"))
        {
			Destroy(gameObject);
		}
		else if (other.CompareTag("Enemy 1"))
		{
			HP hp = other.GetComponent<HP>();
			if (hp!= null)
            {
				hp.DamageReceived(damage);
				hp.HurtSound();
			}

			Destroy(gameObject);
		}
	}


}
