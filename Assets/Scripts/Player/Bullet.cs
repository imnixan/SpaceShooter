using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private RectTransform rt;
    private float damage;
    private float speed = 5;
    private float maxHeight = 1500;
    public void Shoot(float direction, float damage)
    {
        rb = GetComponent<Rigidbody2D>();
        rt = GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;
        rb.velocity = new Vector2(direction, speed);
        this.damage = damage;
        
    }

    public float GetDamage()
    {
        return damage;
    }


    private void LateUpdate()
    {
        if(rt.anchoredPosition.y > maxHeight)
        {
            Destroy(gameObject);
        }
    }
}
