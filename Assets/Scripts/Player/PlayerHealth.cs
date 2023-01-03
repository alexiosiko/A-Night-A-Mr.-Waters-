using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100;
    public void RemoveHealth(float health)
    {
        print("removing " + health);


        this.health -= health;
        CheckHealthBounds();
        UpdateDamageSprite();

        // Gradually increase health
        // But FIRST, cancel all invokes incase already invokiing
        CancelInvoke();
        InvokeRepeating("Heal", 2, 0.2f);
    }
    void Heal()
    {
        health += 5f;

        // If reached maxed health, stop increasing health
        if (health >= 100)
            CancelInvoke();
    }
    void CheckHealthBounds()
    {
        if (health < 0)
            health = 0;
        else if (health > 100)
            health = 100;
    }
    void UpdateDamageSprite()
    {
        healthSprite.color = new Color(1, 1, 1, (100f - health) / 100f);
    }
    void Start()
    {
        UpdateDamageSprite();
    }
    public Image healthSprite;
}
