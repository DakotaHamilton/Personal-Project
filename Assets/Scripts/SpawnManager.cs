using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount;
    private Enemy enemy;

    public float armatureSpeed;
    public GameObject enemyPrefab;
    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Transform spawner4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        

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
