using UnityEngine;

public class ThirdPersonShooter : MonoBehaviour
{
    public GameObject weapon;
    public Camera playerCamera; // Camera Slot
    public Transform weaponPivot; // Weapon Slot
    public GameObject muzzle; // Muzzle Game Object
    public GameObject bulletPrefab; // Bullet Slot
    public Animator anim; // Animator

    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField ]private float lookSensitivity = 5;

    private float nextFireTime;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Instantiate(weapon, weaponPivot);

        muzzle = GameObject.Find("Muzzle");
        GameObject.FindGameObjectsWithTag("Muzzle");
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

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = GetComponent<Rigidbody>();
        }
    }
}
