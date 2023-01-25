using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TMP_Text alertText;
    public void Alert(string text, float waitTime = 2f, bool useBlackScreen = false)
    {
        print("starting alert1");
        StopAllCoroutines();
        StartCoroutine(AlertCoroutine(text, waitTime, useBlackScreen));
    }
    public void Alert(string[] texts, float waitTime = 2f, bool useBlackScreen = false)
    {
        alertText.DOKill();
        StopAllCoroutines();
        StartCoroutine(AlertCoroutine(texts, waitTime, useBlackScreen));
    }
    IEnumerator AlertCoroutine(string text, float waitTime, bool useBlackScreen = false)
    {
        // Reset text
        alertText.alpha = 0;
        
        alertText.text = text;
        if (useBlackScreen == true)
        {
            blackScreen.DOFade(1, 0.7f);
            yield return new WaitForSeconds(1f);
        }


        alertText.DOFade(1, 1f);

        yield return new WaitForSeconds(waitTime);

        alertText.DOFade(0, 1f);

        yield return new WaitForSeconds(1f);

        if (useBlackScreen == true)
            blackScreen.DOFade(0, 0.7f);
    }
    IEnumerator AlertCoroutine(string[] texts, float waitTime, bool useBlackScreen = false)
    {
        // Reset text
        alertText.alpha = 0;

        if (useBlackScreen == true)
            blackScreen.DOFade(1, 0.7f);

        for (int i = 0; i < texts.Length; i++)
        {
            alertText.text = texts[i];
            alertText.DOFade(1, 1f);

            yield return new WaitForSeconds(waitTime + 1f);

            alertText.DOFade(0, 1f);

            yield return new WaitForSeconds(1f);
        }

        if (useBlackScreen == true)
            blackScreen.DOFade(0, 0.7f);
    }
    [SerializeField] Image blackScreen;
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
