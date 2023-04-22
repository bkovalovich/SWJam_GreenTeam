using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootScript : MonoBehaviour
{
    public Transform fireFirePoint;//Where the weapon is used
    public Transform mudFirePoint;
    protected float currentRechargeTime = 0f;//Determines current time between weapon uses
    [SerializeField] protected float rateOfFire;//How often the bullet can be fired
    //[SerializeField] private AudioSource fireSFX;
    public PlayerInputActions playerControls;
    private InputAction shootFire, shootMud, shootClay;
    public GameObject bullet;
    private void Awake() {
        playerControls = new PlayerInputActions();

    }
    private void OnEnable() {
        //Left Click
        shootFire = playerControls.Player.LeftPressed;
        shootFire.Enable();
        shootFire.performed += ShootFireProjectile;
        //Right Click
        shootMud = playerControls.Player.RightPressed;
        shootMud.Enable();
        shootMud.performed += ShootMudProjectile;
        //Middle Click
        shootClay = playerControls.Player.MiddlePressed;
        shootClay.Enable();
        shootClay.performed += ShootClayProjectile;
    }
    private void OnDisable() {
        shootFire.Disable();
        shootMud.Disable();
    }

    public float RateOfFire {
        get { return rateOfFire; }
        set { rateOfFire = value; }
    }

    public void ShootFireProjectile(InputAction.CallbackContext context) {
        PlayerAttackScript.Create(ElementType.Fire, bullet, fireFirePoint);
    }
    public void ShootMudProjectile(InputAction.CallbackContext context) {
        PlayerAttackScript.Create(ElementType.Mud, bullet, mudFirePoint);
    }
    public void ShootClayProjectile(InputAction.CallbackContext context) {
        PlayerAttackScript.Create(ElementType.Clay, bullet, fireFirePoint);
    }
}
