using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    private Camera cam;
    public static Vector3 crosshairPosition;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        crosshairPosition = transform.position;
        Vector2 mousePosition = cam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        crosshairPosition.x = mousePosition.x;
        crosshairPosition.y = mousePosition.y;
        transform.position = crosshairPosition;
    }
}
