using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy
{
    
    private float speedCorrective;
    private float xPos;
    public override void InitializeEnemy(float speedCorrective)
    {
        base.InitializeEnemy(speedCorrective);
        this.speedCorrective = speedCorrective;
        speed = 0.01f * speedCorrective;
        hp = 2;
        xPos = 1.5f;
        movePoint = new Vector2(xPos, transform.position.y);
        Move();
    }
    protected override void AtMoveFinish()
    {
        xPos *= -1;
        movePoint = new Vector2(xPos, transform.position.y);
    }

    
}
