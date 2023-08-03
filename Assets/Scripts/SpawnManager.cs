using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnPowerup;
    private PlayerController player;
    public int enemyCount;
    public int waveCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnEnemyWave(waveCount);
        
        Instantiate(spawnPowerup, GenerateSpawnPos(), spawnPowerup.transform.rotation);


    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
            if (player.gameOver == false)
            {
                Instantiate(spawnPowerup, GenerateSpawnPos(), spawnPowerup.transform.rotation);
            }
                //Instantiate(spawnPowerup, GenerateSpawnPos(), spawnPowerup.transform.rotation);
        }

    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if(player.gameOver == false)
            {
                Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
            }
           
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-9, 9);
        float spawnPosZ = Random.Range(-9, 9);
        Vector3 RandomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return RandomPos;
    }
}
