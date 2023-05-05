using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Button maleButton;
    public Button femaleButton;
    [Space]
    public Button subMainButton;
    public Button subMainBackButton;
    [Space]
    public Button settingsButton;
    public Button settingsBackButton;
    [Space]
    public Slider musicSlider;
    public Slider audioSfxSlider;
    [Space]
    public Button lockerButton;
    public Button lockerBackButton;
    [Space]
    public Button pistolButton;
    public Text pistolButtonText;
    [Space]
    public Button shotgunButton;
    public Text shotgunButtonText;
    [Space]
    public Button assaultRifleButton;
    public Text assaultRifleButtonText;
    [Space]
    public Button creditsButton;
    public Button creditsBackButton;
    [Space]
    public Button quitButton;
    public AudioSource menuAudio;
    public float musicVolume;
    [Space]
    public GameObject mainMenu;
    public GameObject subMainMenu;
    public GameObject settings;
    public GameObject locker;
    public GameObject credits;
    public bool IsGameActive;
    [Space]
    public GameObject[] AvailableWeapons;
    [Space]
    public GameObject[] AvailableAmmunitions;

    public GameObject Weapon { get; set; }
    public GameObject Ammo { get; set; }
    public Button WeaponButton { get; set; }
    public Text WeaponButtonText { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        /*
         * LoadWeaponData();
        */

        maleButton.onClick.AddListener(MaleStart);
        femaleButton.onClick.AddListener(FemaleStart);

        subMainButton.onClick.AddListener(SubMain);
        subMainBackButton.onClick.AddListener(MainMenu);

        settingsButton.onClick.AddListener(Settings);
        settingsBackButton.onClick.AddListener(MainMenu);

        lockerButton.onClick.AddListener(Locker);
        /*
        pistolButton.onClick.AddListener(Pistol);
        shotgunButton.onClick.AddListener(Shotgun);
        assaultRifleButton.onClick.AddListener(AssaultRifle);
        */
        lockerBackButton.onClick.AddListener(MainMenu);

        creditsButton.onClick.AddListener(Credits);
        creditsBackButton.onClick.AddListener(MainMenu);

        quitButton.onClick.AddListener(Quit);
    }

    /*
    public void NewWeaponSelected(GameObject weapon)
    {
        GameManager.Instance.Weapon = weapon;
    }
    */

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

    /*
        public void Pistol()
    {
        pistolButtonText.text = "Equipped";
        shotgunButtonText.text = "Owned";
        assaultRifleButtonText.text = "Owned";
        Weapon = AvailableWeapons[0];
        Ammo = AvailableAmmunitions[0];
        ThirdPersonShooter.fireRate = 0.5f;
        SaveWeaponData();
    }

    public void Shotgun()
    {
        pistolButtonText.text = "Owned";
        shotgunButtonText.text = "Equipped";
        assaultRifleButtonText.text = "Owned";
        Weapon = AvailableWeapons[1];
        Ammo = AvailableAmmunitions[1];
        ThirdPersonShooter.fireRate = 0.7f;
        SaveWeaponData();
    }
    public void AssaultRifle()
    {
        pistolButtonText.text = "Owned";
        shotgunButtonText.text = "Owned";
        assaultRifleButtonText.text = "Equipped";
        Weapon = AvailableWeapons[2];
        Ammo = AvailableAmmunitions[2];
        ThirdPersonShooter.fireRate = 0.1f;
        SaveWeaponData();
    }
    */

    /*
    class SaveData
    {
        public GameObject Gun;
        public GameObject Ammo;
        public Button WeaponSelectButton;
        public Text WeaponSelectText;
    }

    
    private void SaveWeaponData()
    {
        SaveData data = new SaveData
        {
            Gun = Weapon,
            Ammo = Ammo,
            WeaponSelectButton = WeaponButton,
            WeaponSelectText = WeaponButtonText
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadWeaponData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Weapon = data.Gun;
            Ammo = data.Ammo;
            WeaponButton = data.WeaponSelectButton;
            WeaponButtonText = data.WeaponSelectText;
        }
    }
    */

    public void Quit()
    {
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();

#else

        Application.Quit();

#endif

        /*GameManager.Instance.SaveWeaponData();*/
    }
}

