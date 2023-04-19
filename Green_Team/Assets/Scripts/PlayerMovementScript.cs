using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    //PLAYER MOVEMENT STATS
    public float moveSpeed;
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
        moveDirection = move.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        //Debug.Log(moveDirection);
        rb.AddForce(moveDirection * moveSpeed * Time.deltaTime);
    }
}
