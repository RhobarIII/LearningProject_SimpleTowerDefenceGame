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
    private int sellectedAttackPoint;
    private bool reachEnd = false;
    private float counter;
    

    void Start()
    {
        if(path==null)
        {
            path = FindObjectOfType<Path>();
        }
        if (castle == null)
        {
            castle = FindObjectOfType<CastleController>();
        } 
        counter = timeBetweenDmg;
    }
    void Update()
    {
        if(castle.surrendered==false)
        {
            if (reachEnd == false)
            {
                Walk();
            }
            else
            {
                TakingDamage();
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
                sellectedAttackPoint = Random.Range(0, castle.attackPoints.Length);
              
                reachEnd = true;
            }
        }
    }
    void TakingDamage()
    {
        transform.position = Vector3.MoveTowards(transform.position, castle.attackPoints[sellectedAttackPoint].position, moveSpeed * Time.deltaTime);
        transform.LookAt(castle.attackPoints[sellectedAttackPoint]);
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            castle.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
    public void Setup(CastleController newCastle, Path newPath)
    {
        castle = newCastle;
        path = newPath;
    }
}
