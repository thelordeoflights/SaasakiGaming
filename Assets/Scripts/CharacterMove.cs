using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] Vector3 playerMoveInput;
    PlayerMovement playerMovement;

    [SerializeField] CharacterController characterController;
    [SerializeField] Transform playerCamera;
    [SerializeField] float speed;

    void Start()
    {
        playerMovement = new PlayerMovement();
        playerMovement.Enable();

        playerMovement.Movements.Move.performed += ctx =>
        {
            playerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, playerMoveInput.y, ctx.ReadValue<Vector2>().y);
        };
        playerMovement.Movements.Move.canceled += ctx =>
 {
     playerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, playerMoveInput.y, ctx.ReadValue<Vector2>().y);
 };
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 moveVector = transform.TransformDirection(playerMoveInput);
        characterController.Move(moveVector * speed * Time.deltaTime);
    }
}
