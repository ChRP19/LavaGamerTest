using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f;
    public bool move = true;
    void Update()
    {
        if (move)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
