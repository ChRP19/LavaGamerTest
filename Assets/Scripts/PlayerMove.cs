using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
