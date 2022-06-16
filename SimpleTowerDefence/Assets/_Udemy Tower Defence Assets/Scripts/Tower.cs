using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] LayerMask enemy;
    public Collider[] collidersInRange;

   

    void Start()
    {
       
    }

    void Update()
    {
        collidersInRange= Physics.OverlapSphere(transform.position, range,enemy);
        
    }
}
