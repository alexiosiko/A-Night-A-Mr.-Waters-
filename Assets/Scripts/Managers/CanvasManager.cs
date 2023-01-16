using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Internal;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TMP_Text alertText;
    public void Alert(string text, float waitTime)
    {
        StopAllCoroutines();
        StartCoroutine(AlertCoroutine(text, waitTime));
    }
    public void Alert(string text)
    {
        StopAllCoroutines();
        StartCoroutine(AlertCoroutine(text, 2f));
    }
    IEnumerator AlertCoroutine(string text, float waitTime)
    {
        alertText.DOFade(0, 0);
        alertText.text = text;
        alertText.DOFade(1, 0.7f);
        yield return new WaitForSeconds(waitTime);
        alertText.DOFade(0, 0.7f);
    }
    public Image damageSprite;
    public void UpdateDamageSprite(float health)
    {
        float alpha = (50 - health) / 100;

        // Set alpha for damagesprite
        damageSprite.color = new Color(1, 1, 1, alpha);
    }
    public GameObject deathScreen;
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
