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
    public Slider musicSlider;
    public Slider audioSfxSlider;
    public Button settingsBackButton;
    public Button lockerButton;
    public Button lockerBackButton;
    public Button pistolButton;
    public Button shotgunButton;
    public Button assaultRifleButton;
    public Button creditsButton;
    public Button creditsBackButton;
    public AudioSource menuAudio;
    public float musicVolume;
    public GameObject mainMenu;
    public GameObject subMainMenu;
    public GameObject settings;
    public GameObject locker;
    public GameObject credits;
    public bool IsGameActive;
    public bool activeWeapon;
    public GameObject[] weapons;

    private GameObject weapon { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        IsGameActive = false;

        if (weapon == null)
        {
            activeWeapon = false;
        }

        maleButton.onClick.AddListener(MaleStart);
        femaleButton.onClick.AddListener(FemaleStart);

        subMainButton.onClick.AddListener(SubMain);
        subMainBackButton.onClick.AddListener(MainMenu);

        settingsButton.onClick.AddListener(Settings);
        settingsBackButton.onClick.AddListener(MainMenu);

        lockerButton.onClick.AddListener(Locker);
        pistolButton.onClick.AddListener(Weapon);
        shotgunButton.onClick.AddListener(Weapon);
        assaultRifleButton.onClick.AddListener(Weapon);
        lockerBackButton.onClick.AddListener(MainMenu);

        creditsButton.onClick.AddListener(Credits);
        creditsBackButton.onClick.AddListener(MainMenu);
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        subMainMenu.SetActive(false);
        settings.SetActive(false);
        locker.SetActive(false);
        credits.SetActive(false);
    }

    public void SubMain()
    {
        mainMenu.SetActive(false);
        subMainMenu.SetActive(true);
        settings.SetActive(false);
        locker.SetActive(false);
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
        mainMenu.SetActive(false);
        subMainMenu.SetActive(false);
        settings.SetActive(true);
        locker.SetActive(false);
    }

    public void Locker()
    {
        mainMenu.SetActive(false);
        subMainMenu.SetActive(false);
        settings.SetActive(false);
        locker.SetActive(true);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        subMainMenu.SetActive(false);
        settings.SetActive(false);
        locker.SetActive(false);
        credits.SetActive(true);
    }

    public void Weapon()
    {
        if (pistolButton)
        {
            weapon = weapons[0];
        }
        else if (shotgunButton)
        {
            weapon = weapons[1];
        }
        else if (assaultRifleButton)
        {
            weapon = weapons[2];
        }
    }
}
