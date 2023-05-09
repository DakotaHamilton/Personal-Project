using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /* 
       USES CHARACTER-RELATIVE CONTROLS!
       USES A FOLLOW CAMERA!
       THE DIRECTION THE CAMERA IS FACING IS DETERMINED BY THE CHARACTER!
    */
    public Animator anim;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float horizontal; // Left and Right
    private float horizontal2; // Mouse and Touch
    private float vertical; // Forward and Backward
    private float speed = 3.0f; // Movement Speed
    private float rotationSpeed = 50f; // Look Left and Right Speed
    private float gravityValue = -9.81f; // Gravity Value

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.forward * vertical;
        controller.Move(move * Time.deltaTime * speed);
        Vector3 move2 = transform.right * horizontal;
        controller.Move(move2 * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontal2 * rotationSpeed * Time.deltaTime);
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;

        anim.SetFloat("Speed", (float)Mathf.Abs(horizontal + vertical / vertical - horizontal));
    }

    public void Look(InputAction.CallbackContext context)
    {
        horizontal2 = context.ReadValue<Vector2>().x;
    }
}
