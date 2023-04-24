using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount;
    private Enemy enemy;
    private PlayerUI playerUI;
    public int waveCount;

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
            player.GetComponent<ThirdPersonShooter>().playerCamera = Camera.main;
        }
        else if (isMale == false)
        {
            GameObject player = Instantiate(femalePrefab, playerSpawn);
            playerCamera.Follow = player.transform;
            player.GetComponent<ThirdPersonShooter>().playerCamera = Camera.main;
        }
        waveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        if (enemyCount == 0)
        {
            int j = 1;
            waveCount++;

            for (int i = 0; i < 4 * waveCount; i++)
            {
                switch (j)
                {
                    case 1:
                        Instantiate(enemyPrefab, spawner1);
                        break;
                    case 2:
                        Instantiate(enemyPrefab, spawner2);
                        break;
                    case 3:
                        Instantiate(enemyPrefab, spawner3);
                        break;
                    case 4:
                        Instantiate(enemyPrefab, spawner4);
                        break;

                }
                enemyCount++;
                j++;
                if (j > 4)
                {
                    j = 1;
                }
            }
            armatureSpeed += 1;
        }

        if (armatureSpeed > 4)
        {
            armatureSpeed -= 1;
        }
    }
}
