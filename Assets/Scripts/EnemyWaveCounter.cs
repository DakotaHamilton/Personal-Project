using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyWaveCounter : MonoBehaviour
{
    private readonly GameManager gameManager;

    public int totalWaves = 10;
    public int currentWave = 0;

    public TMP_Text waveText;
    public TMP_Text currencyText;

    void Update()
    {
        if (currentWave == totalWaves)
        {
            IsLastWave();
            // Debug.Log("Final Wave!"); // DEBUGGING ONLY
        }

        /*else
        {
            Debug.Log("Not Last Wave!"); // DEBUGGING ONLY
        }
        */
    }

    public void NextWave()
    {
        currentWave++;
    }

    public bool IsLastWave()
    {
        return currentWave == totalWaves;
    }

    public void UpdateWaveText()
    {
        waveText.color = Color.red;
        waveText.text = "Wave " + currentWave;
    }
}
