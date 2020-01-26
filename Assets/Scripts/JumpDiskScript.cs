using UnityEngine;

public class JumpDiskScript : MonoBehaviour
{
    private bool playerEnter = false;
    private int index = 0;
    private int _jumpHeight = 5;
    public JumpData[] jump;
    public bool PlayerEnter { get => playerEnter; set => playerEnter = value; }
    public int _JumpHeight { get => _jumpHeight; set => _jumpHeight = value; }

    private void OnTriggerEnter(Collider other) 
    {
        PlayerEnter = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        PlayerEnter = false;    
    }

    public void JumpSettings()
    {
        if (index == jump.Length)
        {
            index = 0;
        }

        this.transform.localScale = jump[index].JumpDiskScale;
        _JumpHeight = jump[index].JumpHeight;

        index++;
    }
}