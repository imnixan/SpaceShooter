using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDropper : MonoBehaviour
{
    [SerializeField] private GameObject[] bonuses;
    private RectTransform dropperTransform;
    private float width, height;

    private void Start()
    {
        dropperTransform = GetComponent<RectTransform>();
        width = dropperTransform.rect.width;
        height = dropperTransform.rect.height;
    }
    private void OnEnable()
    {
        UiManager.TimeToDropBonus += DropBonus;
    }

    private void OnDisable()
    {
        UiManager.TimeToDropBonus -= DropBonus;
    }
    


    private void DropBonus()
    {
        Instantiate(bonuses[Random.Range(0,bonuses.Length)], dropperTransform).GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(100, width - 100), 100);
    }
}
