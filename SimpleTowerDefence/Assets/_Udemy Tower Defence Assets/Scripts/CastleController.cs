using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleController : MonoBehaviour
{
    [SerializeField] float castleHealth = 100f;

    public Slider healthSilder;
    public Text healthValue;
    

    private float currentCastelHealth;
   
    void Start()
    {
        
        currentCastelHealth = castleHealth;
        healthSilder.maxValue = castleHealth;
        healthSilder.value = currentCastelHealth;
         healthValue.text = castleHealth.ToString()+" / "+castleHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
       
        
    }
    public void TakeDamage(float damageToTake)
    {
        currentCastelHealth -= damageToTake;
        healthSilder.value = currentCastelHealth;
        healthValue.text = currentCastelHealth.ToString() + " / " + castleHealth.ToString();
        if (currentCastelHealth<=0)
        {
            gameObject.SetActive(false);
        }
        
    }
}
