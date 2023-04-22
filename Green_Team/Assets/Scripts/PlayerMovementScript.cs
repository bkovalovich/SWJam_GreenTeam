using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;

    //ADDED anim reference
    [SerializeField]
    private Animator anim;

    //PLAYER MOVEMENT STATS
    public float groundVertSpeed, jumpVertSpeed;
    private float currentVertSpeed;
    private Vector2 moveDirection = Vector2.zero;
    public float acceleration;
    public float maxAirSpeed;
    public float maxGroundSpeed;

    public Vector3 playerVelocity;

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
        
        //ADDED anim param change
        anim.SetFloat("runningTo", moveDirection.x);
    }
    private void FixedUpdate()
    {
        playerVelocity = rb.velocity;
        if (PlayerJumpScript.canJump) {
            if (Mathf.Abs(Vector2.Dot(rb.velocity, Vector2.right)) < maxGroundSpeed)
            {
                rb.AddForce(moveDirection * acceleration);
            }
            else
            {
                playerVelocity.x = moveDirection.x * maxGroundSpeed;
                rb.velocity = playerVelocity;
            }
        } else {
            if (Mathf.Abs(Vector2.Dot(rb.velocity, Vector2.right)) < maxAirSpeed)
            {
                rb.AddForce(moveDirection * acceleration);
            }
            else
            {
                playerVelocity.x = moveDirection.x * maxAirSpeed;
                rb.velocity = playerVelocity;
            }
        }

        //CHANGED movement
        
       
    }
}
