using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerAttackScript : ElementScript {
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Vector2 projectileMotion;
    
    public static GameObject bullet;
    public static PlayerAttackScript Create(ElementType element, GameObject bullet, Transform firepoint) {
        GameObject newObject = Instantiate(bullet, firepoint.position, Quaternion.identity);
        PlayerAttackScript script = newObject.GetComponent<PlayerAttackScript>();
        script.Element = element;
        return script;
    }

    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        if(element == ElementType.Fire) {
            sr.color = new Color(255, 177, 0, 255);
        } else if(element == ElementType.Mud) {
            sr.color = new Color(109, 50, 0, 255);
        }
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
