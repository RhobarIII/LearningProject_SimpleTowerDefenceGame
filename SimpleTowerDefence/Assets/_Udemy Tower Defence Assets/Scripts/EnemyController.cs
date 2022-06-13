using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   [SerializeField] float moveSpeed;
    private Path path;

    private int currentPoint;
    private bool reachEnd = false;

    void Start()
    {
        path = FindObjectOfType<Path>();
    }
    void Update()
    {
        if(reachEnd==false)
        {
            Walk();
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
