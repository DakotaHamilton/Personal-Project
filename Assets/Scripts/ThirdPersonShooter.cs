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
    private Animator animator;
    private ParticleSystem particles;
    private Transform Muzzle;

    /*public GameObject yourWeapon;*/

    private readonly float bulletSpeed = 50;
    private static float fireRate = 0.5f;

    private float nextFireTime;
    private bool OnFire;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject weapon = Instantiate(pistol.pistol, weaponPivot);
        Muzzle = weapon.GetComponent<Pistol>().muzzle;
        particles = weapon.GetComponent<ParticleSystem>();
        audioSource = weapon.GetComponent<AudioSource>();
        animator = weapon.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        nextFireTime = Time.time + fireRate;

        if (OnFire && Time.time >= nextFireTime)
        {
            Debug.Log("Weapon Firing");
            animator.SetBool("IsFiring", true);
            audioSource.Play();
            particles.Play();
            GameObject bullet = Instantiate(bulletPrefab, Muzzle.position, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = playerCamera.transform.forward * bulletSpeed;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        OnFire = context.ReadValueAsButton();
    }
}
