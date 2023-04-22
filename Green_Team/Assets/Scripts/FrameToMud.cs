using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FrameToMud : MonoBehaviour
{
    public GameObject childMud;
    public GameObject childClay;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Mud")){
            Debug.Log("Collison Detected");

            childMud.SetActive(true);
        }
    }
    
}
