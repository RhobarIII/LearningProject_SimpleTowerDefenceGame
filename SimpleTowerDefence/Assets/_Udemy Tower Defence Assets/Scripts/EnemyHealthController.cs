using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] float enemyHealth;
    [SerializeField] Slider healthIndicator;
    [SerializeField] Canvas healthUI;
    
    

    void Start()
    {
        healthUI.worldCamera = FindObjectOfType<Camera>();
        healthIndicator.maxValue = enemyHealth;
        healthIndicator.value = enemyHealth;
        healthUI.gameObject.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.transform.rotation = Camera.main.transform.rotation;
    }
    public void TakeDamage(float amountOfDmg)
    {
        healthUI.gameObject.active = true;
        enemyHealth -= amountOfDmg;
        healthIndicator.value = enemyHealth;
        if(enemyHealth<=0)
        {
            enemyHealth = 0;
            Destroy(gameObject);
        }
    }
}
