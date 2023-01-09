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
        float alpha = (50 - health) / 100;

        // Set alpha for damagesprite
        damageSprite.color = new Color(1, 1, 1, alpha);
    }
    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }
    void Awake()
    {
        instance = this;
    }
    public static CanvasManager instance;
}
