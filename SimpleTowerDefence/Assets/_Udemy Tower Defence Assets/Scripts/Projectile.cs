using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject impactEffect;

    void Start()
    {
        rigidBody.velocity = transform.forward * moveSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

   
}
