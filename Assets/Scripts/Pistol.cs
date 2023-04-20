using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject pistol;
    public Transform muzzle;
    public GameObject millimeterBullets; // 9mm Bullet Prefab

    // Start is called before the first frame update
    void Start()
    {
        muzzle.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
