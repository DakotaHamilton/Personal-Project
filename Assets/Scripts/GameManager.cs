using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button maleButton;
    public Button femaleButton;
    public Button subMainButton;
    public Button subMainBackButton;
    public Button settingsButton;
    public Button settingsBackButton;
    public Button lockerButton;
    public Button lockerBackButton;
    

    public GameObject mainMenu;
    public GameObject subMainMenu;
    public GameObject settings;
    public GameObject locker;
    public bool isActive;

    public Scene male;
    public Scene female;

    // Start is called before the first frame update
    void Start()
    {
        maleButton.onClick.AddListener(MaleStart);
        femaleButton.onClick.AddListener(FemaleStart);

        subMainButton.onClick.AddListener(SubMain);
        subMainBackButton.onClick.AddListener(MainMenu);

        settingsButton.onClick.AddListener(Settings);
        settingsBackButton.onClick.AddListener(MainMenu);

        lockerButton.onClick.AddListener(Locker);
        lockerBackButton.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        subMainMenu.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        locker.gameObject.SetActive(false);
    }

    public void SubMain()
    {
        mainMenu.gameObject.SetActive(false);
        subMainMenu.gameObject.SetActive(true);
        settings.gameObject.SetActive(false);
        locker.gameObject.SetActive(false);
    }

    public void MaleStart()
    {
        SpawnManager.isMale = true;
        SceneManager.LoadScene("Arena");
    }

    public void FemaleStart()
    {
        SpawnManager.isMale = false;
        SceneManager.LoadScene("Arena");
    }

    

    public void Settings()
    {
        mainMenu.gameObject.SetActive(false);
        subMainMenu.gameObject.SetActive(false);
        settings.gameObject.SetActive(true);
        locker.gameObject.SetActive(false);
    }

    public void Locker()
    {
        mainMenu.gameObject.SetActive(false);
        subMainMenu.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        locker.gameObject.SetActive(true);
    }
}
