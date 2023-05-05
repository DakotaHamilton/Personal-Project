using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.IO;

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

    private Transform Muzzle;

    /*public GameObject yourWeapon;*/

    private readonly float bulletSpeed = 50;
    private static float fireRate = 0.5f;

    private float nextFireTime;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameObject weapon = Instantiate(pistol.pistol, weaponPivot);
        Muzzle = weapon.GetComponent<Pistol>().muzzle;
        audioSource = weapon.GetComponent<AudioSource>();
        pistol.animator = weapon.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        /// FOR WEAPON TESTING /// GIVES ALL WEAPONS
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1) && !GameObject.Find("AR - Militaria(Clone)"))
        {
            Destroy(GameObject.Find("HK VP9 9mm Pistol(Clone)"));
            Destroy(GameObject.Find("Shotgun - FirePower(Clone)"));
            GameObject weapon = Instantiate(assaultRifle.assaultRifle, weaponPivot);
            Muzzle = weapon.GetComponent<AssaultRifle>().muzzle;
            bulletPrefab = assaultRifle.caliberBullets;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !GameObject.Find("HK VP9 9mm Pistol(Clone)"))
        {
            Destroy(GameObject.Find("AR - Militaria(Clone)"));
            Destroy(GameObject.Find("Shotgun - FirePower(Clone)"));
            GameObject weapon = Instantiate(pistol.pistol, weaponPivot);
            Muzzle = weapon.GetComponent<Pistol>().muzzle;
            bulletPrefab = pistol.millimeterBullets;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !GameObject.Find("Shotgun - FirePower(Clone)"))
        {
            Destroy(GameObject.Find("AR - Militaria(Clone)"));
            Destroy(GameObject.Find("HK VP9 9mm Pistol(Clone)"));
            GameObject weapon = Instantiate(shotgun.shotgun, weaponPivot);
            Muzzle = weapon.GetComponent<Shotgun>().muzzle;
            bulletPrefab = shotgun.shotgunPellets;
        }
        */

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pistol.animator.SetBool("IsFiring", true);
            audioSource.Play();
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, Muzzle.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = playerCamera.transform.forward * bulletSpeed;
        pistol.animator.SetBool("IsFiring", false);
    }
}
