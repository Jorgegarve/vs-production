using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 4.0f;
    public float gravity = 20.0f;
    public float currentSpeed;

    private Vector3 moveDirection, forward, right;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController> ();
    }

    void Update()
    {
        Move ();   
    }

    private bool isMovementKeyPressed () {
        if (Mathf.Abs(Input.GetAxis ("Horizontal")) >= 0.05 || Mathf.Abs(Input.GetAxis ("Vertical")) >= 0.05)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void Move () {
        forward = GameManager.Instance.cameraController.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize (forward);
        right = Quaternion.Euler (new Vector3 (0, 90, 0)) * forward;

        if (controller.isGrounded)
        {
            if (isMovementKeyPressed ())
            {
                Vector3 rightMovement = right * Input.GetAxis ("Horizontal");
                Vector3 upMovement = forward * Input.GetAxis ("Vertical");

                Vector3 heading = Vector3.Normalize (rightMovement + upMovement);
                transform.forward = heading;
            }
            

            moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
            moveDirection = GameManager.Instance.cameraController.transform.TransformDirection(moveDirection);
            moveDirection.y = 0;
            // moveDirection = Vector3.Normalize (moveDirection);
            moveDirection = moveDirection * speed;
        }
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
    
        controller.Move (moveDirection * Time.deltaTime);
        currentSpeed = Vector3.SqrMagnitude (new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical")) * speed);
    }

    public bool IsWalking ()
    {
        return currentSpeed > 0.1 && currentSpeed < 8 ? true : false;
    }

    public bool IsRunning ()
    {
        return currentSpeed > 8 ? true : false;
    }
}