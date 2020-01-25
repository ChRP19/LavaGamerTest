using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private GameObject jumpDisk;
    private Vector3 mousePos;
    void Update()
    {
        if (jumpDisk.GetComponent<JumpDiskScript>().playerEnter && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                mousePos = hit.point;
            }

            Debug.Log(mousePos.x);
        }
    }
}
