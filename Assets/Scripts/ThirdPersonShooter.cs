using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonShooter : MonoBehaviour
{
    public GameObject weapon;
    public Camera playerCamera; // Camera Slot
    public Transform weaponPivot; // Weapon Slot
    public GameObject muzzle; // Muzzle Game Object
    public GameObject bulletPrefab; // Bullet Slot
    private AssaultRifle assaultRifle;
    private Pistol pistol;
    private Shotgun shotgun;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;

    private float nextFireTime;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        weapon = pistol.pistol;

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
        GameObject bullet = Instantiate(bulletPrefab, weaponPivot.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = playerCamera.transform.forward * bulletSpeed;

    }
}
