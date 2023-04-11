using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour
{
    public GameObject assaultRifle;
    public Transform muzzle;
    public GameObject caliberBullets;

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
