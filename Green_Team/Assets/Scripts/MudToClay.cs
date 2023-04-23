using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudToClay : MonoBehaviour
{
    public GameObject childClay;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Fire")){
           

            childClay.SetActive(true);
        }
        
        if (other.CompareTag("Clay")){
            childClay.SetActive(false);
        }
}
}
