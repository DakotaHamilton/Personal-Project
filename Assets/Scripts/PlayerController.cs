using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* 
       USES CHARACTER-RELATIVE CONTROLS!
       USES A FOLLOW CAMERA!
       THE DIRECTION THE CHARACTER IS FACING IS DETERMINED BY THE CAMERA!
    */

    public Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    [SerializeField] private float speed = 5; // Movement Speed
    [SerializeField] private float tacticalRun = 10; // Tactical Run Speed
    [SerializeField] private float rotationSpeed = 150; // Look Left and Right Speed

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Gets the Left and Right Input
        
        float verticalInput = Input.GetAxis("Vertical"); // Gets the Forward and Back Input
        
        float horizontalInput2 = Input.GetAxis("Mouse X"); // Look Left and Right

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime); // Allows the Character to go Left, Right, Forward, and Back

        transform.Rotate(Vector3.up, horizontalInput2 * rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * speed * tacticalRun * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime);
        }
    }
}
