using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TranIntro : MonoBehaviour
{
    public string[] texts;
    void Start()
    {
        StartCoroutine(AlertCoroutine(texts, 4f));
    }
    [SerializeField] TMP_Text alertText;
    [SerializeField] Image blackScreen;
    IEnumerator AlertCoroutine(string[] texts, float waitTime)
    {
        // Reset text
        alertText.alpha = 0;
        
        for (int i = 0; i < texts.Length; i++)
        {
            alertText.text = texts[i];

            yield return new WaitForSeconds(1f);

            alertText.DOFade(1, 1f);

            yield return new WaitForSeconds(waitTime);

            alertText.DOFade(0, 1f);

            yield return new WaitForSeconds(1f);
        }

        blackScreen.DOFade(0, 0.7f);
    }
}
