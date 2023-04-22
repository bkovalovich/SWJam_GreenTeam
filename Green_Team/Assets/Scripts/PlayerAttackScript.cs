using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerAttackScript : ElementScript {
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public Sprite mud;
    public Sprite fire;
    public Sprite clay;

    public Vector2 projectileDirection;
    public float projectileSpeed;


    public float lifetime;
    private float currentLife;
    private Camera cam;
    
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
            sr.sprite = fire;
        } else if (element == ElementType.Mud) {
            Debug.Log(element);
            sr.sprite = mud;
        }
        else
        {
            Debug.Log(element);
            sr.sprite = clay;
        }
    }
    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void OnEnable() {
        projectileDirection = CrosshairScript.crosshairPosition - transform.position;
        rb.velocity =  projectileDirection.normalized * projectileSpeed;
        Destroy(gameObject, 3f);
    }
    private void OnDisable() {
        //
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        //
    }

}
