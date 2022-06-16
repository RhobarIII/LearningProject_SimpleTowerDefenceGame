using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range=3f;
    [SerializeField] LayerMask enemy;
    [SerializeField] Collider[] collidersInRange;
    public List<EnemyController> enemysInRange=new List<EnemyController>();

    private float checkCounter;
    [SerializeField] float timeCounter = 0.5f;
   

    void Start()
    {
        checkCounter = timeCounter;  
    }

    void Update()
    {
        checkCounter -= Time.deltaTime;
        if(checkCounter<=0)
        {
            collidersInRange = Physics.OverlapSphere(transform.position, range, enemy);
            enemysInRange.Clear();

            foreach (Collider col in collidersInRange)
            {
                enemysInRange.Add(col.GetComponent<EnemyController>());
            }
            checkCounter = timeCounter;
        }

     
    }
}
