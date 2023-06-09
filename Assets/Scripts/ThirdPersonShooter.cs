using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.IO;
using UnityEngine.InputSystem;

public class ThirdPersonShooter : MonoBehaviour
{
    public Camera playerCamera; // Camera Slot
    public Transform weaponPivot; // Weapon Socket
    public GameObject bulletPrefab; // Bullet Slot
    private AssaultRifle assaultRifle; // Assault Rifle 
    public Pistol pistol; // Pistol
    private Shotgun shotgun; // Shotgun
    public AudioSource audioSource; // Audio Source
    private readonly GameManager gameManager;
    private SpawnManager spawnManager;
    private Animator animator;
    private ParticleSystem particles;
    private Transform Muzzle;
    private InputAction fire;
    private InputAction pause;
    public InputActionMap playerActionMap;

    /*public GameObject yourWeapon;*/

    private readonly float bulletSpeed = 50;
    private float fireRate = 0.5f;

    private float nextFireTime;
    private bool hasFired;
    private bool isPaused;
    private void Awake()
    {
        fire = playerActionMap.FindAction("Fire");
        pause = playerActionMap.FindAction("Pause");
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject weapon = Instantiate(pistol.pistol, weaponPivot);
        Muzzle = weapon.GetComponent<Pistol>().muzzle;
        //particles = weapon.GetComponent<Pistol>().muzzleFlash;
        audioSource = weapon.GetComponent<AudioSource>();
        animator = weapon.GetComponent<Pistol>().animator;
    }

    private void OnEnable()
    {
        if (fire != null)
            fire.Enable();
    }

    private void OnDisable()
    {
        if (fire != null)
            fire.Disable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(InputAction.CallbackContext context)
    {
        //Debug.Log("Weapon Firing");

        hasFired = context.ReadValueAsButton();
        Shoot();
    }

    public void FireInput(bool input)
    {
        hasFired = input;
        Shoot();
    }

    public void Shoot()
    {
        if (hasFired && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            animator.SetTrigger("IsFiring");
            audioSource.Play();
            GameObject bullet = Instantiate(bulletPrefab, Muzzle.position, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = playerCamera.transform.forward * bulletSpeed;
        }
        
    }

    public void Pause(InputAction.CallbackContext context)
    {
        Paused();
    }

    public void PauseInput(bool input)
    {
        Paused();
    }

    public void Paused()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            spawnManager.Pause();
        }
        else if(isPaused == false)
        {
            spawnManager.UnPause();
        }
    }
}
