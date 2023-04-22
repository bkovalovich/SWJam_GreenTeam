using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerJumpScript : MonoBehaviour {
    private Rigidbody2D rb;
    public PlayerInputActions playerControls;
    private InputAction jump;
    public float jumpSpeed;
    public static bool canJump;

    //ADDED
    public Animator anim;


    private void Awake() {
        rb = GetComponentInParent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
    }
    private void OnEnable() {
        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }
    private void OnDisable() {
        jump.Disable();
    }
    private void Jump(InputAction.CallbackContext context) {
        if (canJump) {
            rb.AddForce(Vector3.up * jumpSpeed);
            canJump = false;

            //ADDED set animator state to jump
            anim.Play("Player_Jump", -1, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        canJump = true;
    }
}
