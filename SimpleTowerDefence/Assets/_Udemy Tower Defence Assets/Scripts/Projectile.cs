using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float moveSpeed;

    void Start()
    {
        rigidBody.velocity = transform.forward * moveSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
