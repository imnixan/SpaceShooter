using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiesPref;
    private EnemyType enemy;
    private RectTransform spawnerTransform;
    private RectTransform newEnemy;
    private int maxEnemyCount, enemyCount, maxSpaces;
    private float speedCorrective = 1;
    private int minEnemiesCount = 1;
    private enum EnemyType
    {
        Ram,
        Miner,
        Shooter
    };


    private void UpSpeedCorrective()
    {
        speedCorrective += speedCorrective * 0.05f;
    }

    private void UpMinEnemiesCount()
    {
        minEnemiesCount ++;
    }

    private void Start()
    {
        spawnerTransform = GetComponent<RectTransform>();
    }


    private void LateUpdate()
    {
        if(spawnerTransform.childCount <= minEnemiesCount)
        {
            UpSpeedCorrective();
            SpawnEnemies(Random.Range(0, enemiesPref.Length));
        }
    }
    

    private void SpawnEnemies(int enemyType)
    {
        enemy = (EnemyType)enemyType;

        switch(enemy)
        {
            case EnemyType.Ram:
                SpawnRams();
                break;
            case EnemyType.Miner:
                SpawnMiners();
                break;
            case EnemyType.Shooter:
                SpawnShooters();
                break;
        }
    }


    public void RandomSpawnRams()
    {
        if(Random.Range(0,40) > 37)
        {
            enemy = EnemyType.Ram;
            SpawnRams();
        }
    }

    private void SpawnRams()
    {
        maxEnemyCount = (int)(spawnerTransform.rect.width / enemiesPref[(int)enemy].GetComponent<RectTransform>().sizeDelta.x) - 2;
        enemyCount = Random.Range(1, maxEnemyCount+1);
        maxSpaces = maxEnemyCount - enemyCount;
        for(int i = 0; i < maxEnemyCount; i ++)
        {
            if(maxSpaces > 0)
            {
                if(Random.Range(0,2) > 0)
                {
                    maxSpaces --;
                    continue;
                }
            }
            newEnemy = Instantiate(enemiesPref[(int)enemy], spawnerTransform).GetComponent<RectTransform>();
            newEnemy.anchoredPosition = new Vector2(newEnemy.sizeDelta.x/2 + newEnemy.sizeDelta.x * i,
                spawnerTransform.rect.height + newEnemy.sizeDelta.y * Random.Range(1, enemyCount+1));
            newEnemy.GetComponent<Enemy>().InitializeEnemy(speedCorrective);

        }
    }

    private void SpawnMiners()
    {
        maxEnemyCount = 3;
        enemyCount = Random.Range(1, maxEnemyCount+1);
        for(int i = 0; i < enemyCount; i++){
            newEnemy = Instantiate(enemiesPref[(int) enemy], spawnerTransform).GetComponent<RectTransform>();
            newEnemy.anchoredPosition = new Vector2(Random.Range(newEnemy.sizeDelta.x/2, spawnerTransform.rect.width - newEnemy.sizeDelta.x/2),
                spawnerTransform.rect.height + newEnemy.sizeDelta.y * Random.Range(1, enemyCount+1));
            newEnemy.GetComponent<Enemy>().InitializeEnemy(speedCorrective);
        }
    }
    
    private void SpawnShooters()
    {
        maxEnemyCount = (int)(spawnerTransform.rect.width / enemiesPref[(int)enemy].GetComponent<RectTransform>().sizeDelta.x) - 2;
        enemyCount = Random.Range(1, maxEnemyCount+1);
        for(int i = maxEnemyCount - 1; i >= 0; i --)
        {
            newEnemy = Instantiate(enemiesPref[(int)enemy], spawnerTransform).GetComponent<RectTransform>();
            newEnemy.anchoredPosition = new Vector2(newEnemy.sizeDelta.x/2 - (newEnemy.sizeDelta.x * 1.5f * i),
                newEnemy.sizeDelta.y * i);
            newEnemy.GetComponent<Enemy>().InitializeEnemy(speedCorrective);

        }
    }

    private void OnEnable()
    {
        UiManager.TimeToDropBonus += UpMinEnemiesCount;
    }

    private void OnDisable()
    {
        UiManager.TimeToDropBonus -= UpMinEnemiesCount;
    }
}
