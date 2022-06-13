using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    [SerializeField] float castleHealth = 100f;
    private float currentCastelHealth;
    void Start()
    {
        currentCastelHealth = castleHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageToTake)
    {
        currentCastelHealth -= damageToTake;
        if(currentCastelHealth<=0)
        {
            gameObject.SetActive(false);
        }
    }
}
