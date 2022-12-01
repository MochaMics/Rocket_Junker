using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public float spawnStart;
    public float spawnRate;
    public float enemySpawnCap;

    public GameManager gameManager;


    // Update is called once per frame
    void Start()
    {
        //InvokeRepeating("SpawnEnemy", spawnStart, spawnRate);
        //if(GameObject.FindGameObjectsWithTag("Enemy").Length == enemySpawnCap)
        //{
        //   spawnStart = 0;
        //    spawnRate = 0;
        //   enemySpawnCap = 0;
        //}


        if (GameObject.FindGameObjectsWithTag("Enemy").Length < enemySpawnCap)
        {
            InvokeRepeating("SpawnEnemy",spawnStart,spawnRate);
        }
        else if(GameObject.FindGameObjectsWithTag("Enemy").Length <= enemySpawnCap)
        {
            CancelInvoke();
        }


    }

    void SpawnEnemy()
    {
        if (gameManager.gameOver == true)
        {
            Debug.Log("stop hamma time");
            CancelInvoke();
            return;
        }

        Instantiate(enemy, transform.position, transform.rotation);
    }


}
