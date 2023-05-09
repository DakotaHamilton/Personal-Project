using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount;
    public EnemyWaveCounter waveCounter;
    private readonly GameManager gameManager;
    private ThirdPersonShooter thirdPersonShooter;
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
    [Space]
    
    public GameObject GameOver;
    public Button RetryButton;
    public Button MainMenuButton;
    


    // Start is called before the first frame update
    void Start()
    {
        if (isMale == true)
        {
            GameObject player = Instantiate(malePrefab, playerSpawn);
            playerCamera.Follow = player.transform;
            player.GetComponent<ThirdPersonShooter>().playerCamera = Camera.main;
        }
        if (isMale == false)
        {
            GameObject player = Instantiate(femalePrefab, playerSpawn);
            playerCamera.Follow = player.transform;
            player.GetComponent<ThirdPersonShooter>().playerCamera = Camera.main;
        }
        waveCount = 0;

        //InGame Buttons

        RetryButton.onClick.AddListener(Retry);
        MainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    // InGame Buttons Function
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnDeath()
    {
        GameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            StartCoroutine(SpawnWave());
        }
        /*
        if (armatureSpeed > 4)
        { 
            armatureSpeed -= 1; 
        }
        */
    }

    IEnumerator SpawnWave()
    {
        int j = 1;
        {
            waveCount++;
            waveCounter.NextWave();
            waveCounter.UpdateWaveText();

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
            armatureSpeed += 0.2f;
        }

        yield return enemyCount;
    }
}
