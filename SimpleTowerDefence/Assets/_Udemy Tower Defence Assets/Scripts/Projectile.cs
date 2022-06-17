using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject impactEffect;
    [SerializeField] float damage;

    private bool hasDamaged;
    void Start()
    {
        rigidBody.velocity = transform.forward * moveSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        if(other.tag=="Enemy" && hasDamaged==false)
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damage);
            hasDamaged = true;
        }
        Destroy(gameObject);

      
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

   
}
