using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerAttackScript : ElementScript {
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Vector2 projectileMotion;
    public float lifetime;
    private float currentLife;
    
    public static GameObject bullet;
    public static PlayerAttackScript Create(ElementType element, GameObject bullet, Transform firepoint) {
        GameObject newObject = Instantiate(bullet, firepoint.position, Quaternion.identity);
        PlayerAttackScript script = newObject.GetComponent<PlayerAttackScript>();
        script.Element = element;
        script.ChangeColor();
        return script;
    }
    public void ChangeColor() {
        if (element == ElementType.Fire) {
            Debug.Log(element);
            sr.material.color = Color.red;
        } else if (element == ElementType.Mud) {
            Debug.Log(element);
            sr.material.color = Color.black;
        }
    }
    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnEnable() {
        rb.AddForce(projectileMotion);
    }
    private void OnDisable() {
        //
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        //
    }
}
