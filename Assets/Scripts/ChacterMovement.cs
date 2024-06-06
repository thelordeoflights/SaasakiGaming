using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChacterMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Animator animator;
    [SerializeField] GameObject GameOver;
    [SerializeField] PlayerState playerState;
    private Vector3 playerVelocity;
    public bool groundedPlayer;

    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        GameOver.SetActive(false);
        playerState.isDead = false;
        playerState.canJump = true;

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Laser" && !playerState.isDead)
        {
            GameOver.SetActive(true);
            playerState.isDead = true;
            animator.SetTrigger("_Death");
        }


    }


    void Update()
    {
        if (!playerState.isDead)
        { Move(); }
        if (controller.isGrounded)
        {
            playerState.canJump = true;
        }
    }

    private void Move()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (playerInput.actions["Move"].triggered || playerInput.actions["Move"].IsPressed())
        {
            animator.SetFloat("_Movement", 1);
            // animator.SetTrigger("_Run");
            // animator.ResetTrigger("_Idle");
        }
        else
        {
            animator.SetFloat("_Movement", 0);
            // animator.ResetTrigger("_Run");
            // animator.SetTrigger("_Idle");
        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (playerState.canJump && playerInput.actions["Jump"].triggered)
        {
            animator.SetTrigger("_Jump");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            playerState.canJump = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}
