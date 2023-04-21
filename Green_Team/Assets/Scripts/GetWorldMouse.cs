using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWorldMouse : MonoBehaviour
{
    // This gets the mouses world position in relation to the camera
    public static Vector3 GetMouseWorldPosition(){
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ(){
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldcamera){
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldcamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldcamera){
        Vector3 worldPosition = worldcamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
