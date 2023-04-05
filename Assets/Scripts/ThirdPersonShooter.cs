using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonShooter : MonoBehaviour
{
    public Camera playerCamera; // Camera Slot
    public Transform weaponPivot; // Weapon Socket
    public GameObject bulletPrefab; // Bullet Slot
    public AssaultRifle assaultRifle; // Assault Rifle 
    public Pistol pistol;
    public Shotgun shotgun;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;

    private float nextFireTime;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Instantiate(pistol.pistol, weaponPivot);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(pistol.millimeterBullet, pistol.muzzle.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = playerCamera.transform.forward * bulletSpeed;

    }
}
