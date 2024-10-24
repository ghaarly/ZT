using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]  
public class Controller : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed =6f;
    public float runSpeed = 10f;
    private float forceJump = 5f;
    private float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 50f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0f;

    public bool canMove =true;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        #region Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float cursorSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float cursorSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * cursorSpeedX) + (right* cursorSpeedY);
        #endregion

        #region Jumping
        if(Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = forceJump;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!characterController.isGrounded) 
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        #endregion

        #region Rotation    
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove) 
        {
            rotationX += Input.GetAxis("Mouse Y") * -lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        #endregion
    }
}