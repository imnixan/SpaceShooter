using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : Enemy
{

    public override void InitializeEnemy(float speedCorrective)
    {
        base.InitializeEnemy(speedCorrective);
        speed = 0.01f * speedCorrective;
        hp = 3;
        movePoint = new Vector2(enTransform.position.x, minBorder);
        Move();
    }
    protected override void AtMoveFinish()
    {
        Destroy(gameObject);
    }

}
