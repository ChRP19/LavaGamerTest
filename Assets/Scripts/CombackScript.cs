using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombackScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        other.gameObject.transform.position = new Vector3(-15, 1.1f, 0);        
    }
}
