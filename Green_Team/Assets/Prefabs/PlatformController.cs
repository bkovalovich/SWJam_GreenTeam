using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{





    public Transform posA, posB, posC, posD;
    public int Speed;
    Vector2 targetPos;


    private void Start()
    {
        targetPos = posB.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;

        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posC.position;

        if (Vector2.Distance(transform.position, posC.position) < .1f) targetPos = posD.position;

        if (Vector2.Distance(transform.position, posD.position) < .1f) targetPos = posA.position;


        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}
