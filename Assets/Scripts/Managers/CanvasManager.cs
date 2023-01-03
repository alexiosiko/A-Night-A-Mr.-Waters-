using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject deathScreen;
    public Image damageSprite;
    public void UpdateDamageSprite(float health)
    {
        if (health <= 0)
            deathScreen.SetActive(true);
            
        // Convert health to appropriate alpha value
        // if (health == 50), alpha = 0.5
        // if (health == 25), alpha = 0.25
        // if (health == 0), alpha = 0
        
        float alpha = (50 - health) / 100;

        // Set alpha for damagesprite
        damageSprite.color = new Color(1, 1, 1, alpha);
    }
    void Awake()
    {
        instance = this;
    }
    public static CanvasManager instance;
}
