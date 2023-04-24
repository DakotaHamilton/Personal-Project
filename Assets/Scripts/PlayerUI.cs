using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    /// <summary>
    /// ALL OF THIS NEEDS TO BE MOVED TO THE SPAWN MANAGER YA DINGUS!!!!
    /// </summary>

    public TextMeshProUGUI waveText;
    private SpawnManager spawnManager;
    public int waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        CurrentWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void CurrentWave(int Wave)
    {
        Wave += waveNumber;
        waveText.text = "Wave " + waveNumber;
    }
}
