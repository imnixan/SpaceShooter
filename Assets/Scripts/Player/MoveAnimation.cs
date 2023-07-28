using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private Sprite left, central, right;
    private Rigidbody2D rb;
    private Image image;

   public void Initialize()
   {
        rb = GetComponent<Rigidbody2D>();
        image = GetComponent<Image>();
   }

   private void LateUpdate()
   {
        if(rb){
            if(rb.velocity.x == 0)
            {
                image.sprite = central;
            }
            else if(rb.velocity.x > 0)
            {
                image.sprite = right;
            }
            else
            {
                image.sprite = left;
            }
        }
   }
   
}
