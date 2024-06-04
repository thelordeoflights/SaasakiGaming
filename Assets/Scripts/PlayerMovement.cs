using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] CharacterState characterState;
    [SerializeField] Animator animator;

    [SerializeField] float jumpSpeed;
    float ySpeed;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    Vector2 input;

    void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        if (playerInput.actions["Move"].triggered || playerInput.actions["Move"].IsPressed() && characterState.activeStates != CharacterState.States.Jumping)
        {
            characterState.activeStates = CharacterState.States.Sprint;
        }
        if (playerInput.actions["Jump"].triggered)
        {
            characterState.activeStates = CharacterState.States.Jumping;
        }
        else
        {
            characterState.activeStates = CharacterState.States.Idle;
        }
        CheckState();
    }
    void CheckState()
    {
        switch (characterState.activeStates)
        {
            case CharacterState.States.Sprint:
                input = playerInput.actions["Move"].ReadValue<Vector2Int>();
                animator.SetTrigger("_Run");
                animator.ResetTrigger("_Idle");
                animator.ResetTrigger("_Jump");
                Movement();
                break;
            case CharacterState.States.Idle:
                input = Vector2.zero;
                animator.SetTrigger("_Idle");
                animator.ResetTrigger("_Run");
                animator.ResetTrigger("_Jump");
                break;
            case CharacterState.States.Jumping:
                Jump();
                animator.SetTrigger("_Jump");
                animator.ResetTrigger("_Run");
                animator.ResetTrigger("_Idle");
                break;

        }
    }
    public void Jump()
    {
        if (controller.isGrounded)
        {
            ySpeed = -0.5f;
            ySpeed = jumpSpeed;
            characterState.activeStates = CharacterState.States.Jumping;
        }

    }

    private void Movement()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(input.x, 0, input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (playerInput.actions["Jump"].triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

