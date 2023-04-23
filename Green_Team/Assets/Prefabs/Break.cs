using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public Transform origin;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((transform.position - origin.position)*100);
        rb.AddTorque(Random.Range(-100, 100));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
