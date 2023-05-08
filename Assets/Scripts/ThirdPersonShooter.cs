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
    private bool hasFired;

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

    }

    public void Shoot(InputAction.CallbackContext context)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        hasFired = context.ReadValueAsButton();

        GameObject bullet = Instantiate(bulletPrefab, Muzzle.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = playerCamera.transform.forward * bulletSpeed;
        nextFireTime = Time.time + fireRate;

        audioSource.PlayOneShot(audioSource.clip);
        particles.Play();
        animator.SetBool("IsFiring", true);
    }
}
