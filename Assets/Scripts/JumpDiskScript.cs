using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDiskScript : MonoBehaviour
{
    public bool playerEnter = false;
    public int score;
    private void OnTriggerEnter(Collider other) 
    {
        playerEnter = true;
        score++;
    }

    private void OnTriggerExit(Collider other) 
    {
        playerEnter = false;    
    }
}
