using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    //PLAYER MOVEMENT STATS
    public float groundVertSpeed, jumpVertSpeed;
    private float currentVertSpeed;
    private Vector2 moveDirection = Vector2.zero;
    //INPUT SYSTEM
    public PlayerInputActions playerControls;    
    private InputAction move;
    private InputAction jump;

    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
    }
    private void OnEnable() {
        move = playerControls.Player.Move;
        move.Enable();

    }
    private void OnDisable() {
        move.Disable();
    }

    private void Update() {
        moveDirection.x = move.ReadValue<Vector2>().x;
    }
    private void FixedUpdate()
    {
        if (!PlayerJumpScript.canJump) {
            currentVertSpeed = jumpVertSpeed;
        } else {
            currentVertSpeed = groundVertSpeed;
        }
        rb.AddForce(moveDirection * currentVertSpeed * Time.deltaTime);
    }
}
