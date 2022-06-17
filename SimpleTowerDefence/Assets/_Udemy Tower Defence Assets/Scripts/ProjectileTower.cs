using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    private Tower theTower;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform firePoint;
    [SerializeField] float timeBetweenShoots;
    [SerializeField] Transform weaponType;

    private float shotCounter;
    private Transform target;
  
    void Start()
    {
        theTower = GetComponent<Tower>();
        shotCounter = timeBetweenShoots;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(target!=null)
        {
           // weaponType.LookAt(target);
            weaponType.rotation =Quaternion.Slerp(weaponType.rotation, Quaternion.LookRotation(target.position-transform.position),5f *Time.deltaTime);
            weaponType.rotation = Quaternion.Euler(0f, weaponType.rotation.eulerAngles.y, 0f);
        }

        shotCounter -= Time.deltaTime;
        if(shotCounter<=0&&target!=null)
        {
            shotCounter = timeBetweenShoots;
            firePoint.LookAt(target);
            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }
        if(theTower.enemyUpdated)
        {
            if (theTower.enemysInRange.Count > 0)
            {
                float minDistance = theTower.range + 1f;
                foreach (EnemyController enemy in theTower.enemysInRange)
                {
                    if (enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                        }

                    }
                    else
                    {
                        target = null;
                    }
                }
            }
        }
        
    
    }
}
