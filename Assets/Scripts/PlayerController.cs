using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* 
       USES CHARACTER-RELATIVE CONTROLS!
       USES A FOLLOW CAMERA!
       THE DIRECTION THE CAMERA IS FACING IS DETERMINED BY THE CHARACTER!
    */
    public Animator anim;
    public Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    [SerializeField] private float speed; // Movement Speed
    [SerializeField] private float tacticalRun; // Tactical Run Speed
    [SerializeField] private float rotationSpeed; // Look Left and Right Speed

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Gets the Left and Right Input
        
        float verticalInput = Input.GetAxis("Vertical"); // Gets the Forward and Back Input
        
        float horizontalInput2 = Input.GetAxis("Mouse X"); // Look Left and Right

        transform.Translate(speed * Time.deltaTime * new Vector3(horizontalInput, 0, verticalInput)); // Allows the Character to go Left, Right, Forward, and Back

        transform.Rotate(Vector3.up, horizontalInput2 * rotationSpeed * Time.deltaTime); // Looks Left and Right on the X Axis

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(speed * tacticalRun * Time.deltaTime * new Vector3(horizontalInput, 0, verticalInput));
        }
        
        anim.Play("Walking");
    }
}
