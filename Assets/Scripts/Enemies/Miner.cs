using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Enemy
{   
    private EnemiesSpawner enemiesSpawner;
    private float speedCorrective;
    public override void InitializeEnemy(float speedCorrective)
    {
        base.InitializeEnemy(speedCorrective);
        this.speedCorrective = speedCorrective;
        enemiesSpawner = GetComponentInParent<EnemiesSpawner>();
        speed = 0.03f * speedCorrective;
        hp = 5;
        movePoint = new Vector2(enTransform.position.x, Random.Range(0f, 2f));
        Move();
    }
    protected override void AtMoveFinish()
    {
        speed = 0.01f * speedCorrective;
        movePoint = new Vector2(Random.Range(-1.5f,1.5f), Random.Range(0f, 2f));
        enemiesSpawner.RandomSpawnRams();
    }

    

    
}
