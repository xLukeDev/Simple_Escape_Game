using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public static HealthManager HM;
    
    [Header("HP/MANA/AMMO")] 
    public Image healthBar;
    public float healthAmount = 100f;
    public int canHeal = 0;
    public TextMeshProUGUI healthText;
    
    public void Awake()
    {
        HM = this;
    }

    public void Update()
    {
        if (canHeal > 0 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Heal(20);
            
        }
        updateUI();
        
    }
    
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float amount)
    {
        healthAmount += amount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        
        healthBar.fillAmount = healthAmount / 100f;
        canHeal -= 1;
    }

    public void updateUI()
    {
        healthText.text = "Ilość użyć krzyształu: " + canHeal.ToString();
    }
    
}
