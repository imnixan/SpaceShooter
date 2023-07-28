using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
     GameObject smallExplosion, shipExplosion;
     protected Rigidbody2D rb;
     protected RectTransform enTransform;
     protected float hp;
     protected Vector2 movePoint;
     protected float speed;
     protected float xBorder;
     protected float minBorder;
     public Vector2 pos;
     public virtual void InitializeEnemy(float speedCorrective)
     {
          rb = gameObject.AddComponent<Rigidbody2D>();
          rb.gravityScale = 0;
          enTransform = GetComponent<RectTransform>();
          xBorder = enTransform.parent.GetComponent<RectTransform>().rect.size.x;
          minBorder = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
          smallExplosion = Resources.Load("ExplosionPrefabs/SmallExplosion") as GameObject;
          shipExplosion = Resources.Load("ExplosionPrefabs/ShipExplosion") as GameObject;
     }
     protected void LateUpdate()
     {
          if(DestinationReached())
          {
               AtMoveFinish();
          }
     }

     protected bool DestinationReached()
     {
        if((Vector2)enTransform.position == movePoint)
        {
            return true;
        }
        return false;
     }

     protected void Move()
     {
          StartCoroutine(ReachDestination());
     }

    protected IEnumerator ReachDestination()
    {
        while(hp > 0)
        {
            rb.MovePosition(Vector2.MoveTowards(enTransform.position, movePoint, speed));
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

     protected abstract void AtMoveFinish();

     protected void OnTriggerEnter2D(Collider2D other)
     {
          if(other.CompareTag("PlayerBullet"))
          {
               Instantiate(smallExplosion, other.transform.position, new Quaternion(), enTransform.parent);
               hp -= other.GetComponent<Bullet>().GetDamage();
               Destroy(other.gameObject);
          }
          if(hp <= 0)
          {
               Instantiate(shipExplosion, enTransform.position, new Quaternion(), enTransform.parent);
               Destroy(gameObject);
          }
     }
}
