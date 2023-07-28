using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shield : MonoBehaviour
{
    [SerializeField] private Sprite[] shieldSprites;
    private Image image;



    public void DestroyShield()
    {
        StartCoroutine(HideShield());
    }

    IEnumerator ShowShield()
    {
        for(int i = 0; i < shieldSprites.Length; i ++)
        {
            image.sprite = shieldSprites[i];
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator HideShield()
    {
        for(int i = shieldSprites.Length - 1; i >= 0; i--)
        {
            image.sprite = shieldSprites[i];
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.SetActive(false);
    }

    private void OnEnable(){
        image = GetComponent<Image>();
        StartCoroutine(ShowShield());
    }
}
