using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount;
    private Enemy enemy;

    public float armatureSpeed;
    public GameObject enemyPrefab;
    public GameObject malePrefab;
    public GameObject femalePrefab;
    public CinemachineVirtualCamera playerCamera;
    public static bool isMale;
    public Transform playerSpawn;
    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Transform spawner4;
    

    // Start is called before the first frame update
    void Start()
    {
        if (isMale == true)
        {
            GameObject player = Instantiate(malePrefab, playerSpawn);
            playerCamera.Follow = player.transform;
        }
        else if (isMale == false)
        {
            GameObject player = Instantiate(femalePrefab, playerSpawn);
            playerCamera.Follow = player.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyCount == 0)
        {
            Instantiate(enemyPrefab, spawner1);
            Instantiate(enemyPrefab, spawner2);
            Instantiate(enemyPrefab, spawner3);
            Instantiate(enemyPrefab, spawner4);
            enemyCount++;
            armatureSpeed += 1;
        }

        if (armatureSpeed > 4)
        {
            armatureSpeed -= 1;
        }
    }
}
