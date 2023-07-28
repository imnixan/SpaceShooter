using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private RectTransform rt;
    private float minHeigth;
    public GameObject gun;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        minHeigth = rt.parent.GetComponent<RectTransform>().rect.height * -1 + 100;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
    }

    private void Update()
    {
        if(rt.anchoredPosition.y < minHeigth)
        {
            Destroy(gameObject);
        }
    }



    
}
