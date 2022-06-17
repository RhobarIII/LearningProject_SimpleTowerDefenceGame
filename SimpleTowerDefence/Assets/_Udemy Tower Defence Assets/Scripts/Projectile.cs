using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject impactEffect;
    [SerializeField] float damage;
  
   

    
    

    void Start()
    {
        rigidBody.velocity = transform.forward * moveSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        if(other.tag=="Enemy")
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damage);
        }
        Destroy(gameObject);
      
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

   
}
