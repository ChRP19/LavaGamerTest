using UnityEngine;

public class CombackScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        other.gameObject.transform.position = new Vector3(-15, 1.3f, 0);        
    }
}
