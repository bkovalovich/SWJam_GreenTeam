using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCups : MonoBehaviour
{
    private Transform aimTransform;
    // gets the transform point "Aim"
    private void Awake() {
        aimTransform = transform.Find("Aim");
    }
    // References the GetWorldMouse script, converts to euler angle, and then converts back to degrees
    private void Update() {
        Vector3 mousePosition = GetWorldMouse.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
    }
    
    

}
