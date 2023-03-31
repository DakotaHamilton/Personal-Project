using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float speed = 1;
    public int enemyCount;

    public GameObject enemyPrefab;
    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;
    public Transform spawner4;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Spawner1 = GameObject.Find("Spawner #1");
        GameObject Spawner2 = GameObject.Find("Spawner #2");
        GameObject Spawner3 = GameObject.Find("Spawner #3");
        GameObject Spawner4 = GameObject.Find("Spawner #4");

        Instantiate(enemyPrefab, spawner1);
        Instantiate(enemyPrefab, spawner2);
        Instantiate(enemyPrefab, spawner3);
        Instantiate(enemyPrefab, spawner4);
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
        }
    }
}
