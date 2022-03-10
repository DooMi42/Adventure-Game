using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController playerController;

    [Header("Move")]
    [SerializeField]
    private float turnSpeed = 150f;
    [SerializeField]
    private float forwardMoveSpeed = 7.5f;
    [SerializeField]
    private float backwardMoveSpeed = 3f;

    [Header("Jump")]
    [SerializeField]
    private float jumpStrength = 0.4f;
    private float jumpAcceleration = 0;
    private int jumpCount = 0;

    private float horizontal;
    private float vertical;

    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseKeyboardInputs();

        Movements();
    }
    private void MouseKeyboardInputs()
    {
        horizontal = Input.GetAxis("Mouse X");

        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < 2)
            {
                jumpAcceleration = jumpStrength;

                jumpCount += 1;
            }
        }
    }
    private void Movements()
    {
        animator.SetFloat("runningSpeed", vertical);
        animator.SetFloat("jumpingSpeed", jumpAcceleration);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if (vertical != 0)
        {
            float moveSpeedToUse = (vertical > 0) ? forwardMoveSpeed: backwardMoveSpeed;
            playerController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }

        if (jumpAcceleration != 0)
        {
            Vector3 jumping = new Vector3(0, jumpAcceleration, 0);
            playerController.Move(jumping);
        }

        if (playerController.isGrounded)
        {
            jumpCount = 0;
        }

        if (jumpAcceleration > -0.98f)
        {
            jumpAcceleration = Mathf.MoveTowards(jumpAcceleration, -0.98f, Time.deltaTime * 2);
        }
    }
}
