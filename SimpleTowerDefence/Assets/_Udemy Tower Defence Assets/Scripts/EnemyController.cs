using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float timeBetweenDmg;
    [SerializeField] float damage;

    private Path path;
    private CastleController castle;

    private int currentPoint;
    private bool reachEnd = false;
    private float counter;
    

    void Start()
    {
        path = FindObjectOfType<Path>();
        castle = FindObjectOfType<CastleController>();
        counter = timeBetweenDmg;
    }
    void Update()
    {
        if(reachEnd==false)
        {
            
            Walk();
        }
        else
        {
            counter -= Time.deltaTime;
            if(counter<=0)
            {
                castle.TakeDamage(damage);
                gameObject.SetActive(false);
            }
        }
    
    }
  
    void Walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.points[currentPoint].position, moveSpeed * Time.deltaTime);
        transform.LookAt(path.points[currentPoint]);
        if (Vector3.Distance(transform.position, path.points[currentPoint].position) < 0.1f)
        {
            currentPoint++;
            if (path.points.Length <= currentPoint)
            {
                reachEnd = true;
            }
        }

    }
}
