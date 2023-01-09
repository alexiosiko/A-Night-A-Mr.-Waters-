using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 50;
    public void ChangeHealth(float health)
    {
        this.health += health;
        CheckHealthBounds();
        CanvasManager.instance.UpdateDamageSprite(this.health);

        // Gradually increase health
        // But FIRST, cancel all invokes incase already invokiing
        // But ALSO, if the change in health is negative,that means it's 
        // damage, so restart heal timer. If change in health is positive,
        // then we are healing and therefore do not invoke heal again
        if (health < 0)
        {
            CancelInvoke();
            InvokeRepeating("Heal", 4f, 0.2f);
        }
    }
    void Heal()
    {
        ChangeHealth(5);

        // If reached maxed health, stop increasing health
        if (health >= 100)
        {
            print("Cancel invoking");
            CancelInvoke();
        }
    }
    void CheckHealthBounds()
    {
        // We range between [50, 100]
        // I use this because i
        if (health < 0)
        {
            health = 0;

            StartCoroutine(KillPlayer());
        }
        else if (health > 50)
            health = 50;
    }
    IEnumerator KillPlayer()
    {
        // Death animation
        animator.Play("die");

        // Freeze character movements
        StatusManager.instance.freeze = false;

        yield return new WaitForSeconds(2f);

        CanvasManager.instance.ShowDeathScreen();
    }
    void UpdateDamageSprite()
    {
        // Flip the health value to correpsond to the
        // appropiate alpha for damage sprite
        float alpha = 50 - health;

        // Set alpha for damagesprite
        damageSprite.color = new Color(1, 1, 1, alpha);
    }
    void Start()
    {
        UpdateDamageSprite();
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    Animator animator;
    public Image damageSprite;
}
