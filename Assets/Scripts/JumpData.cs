using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JumpData : ScriptableObject
{
    [SerializeField] private int jumpHeight;
    [SerializeField] private Vector3 jumpDiskScale;
    public int JumpHeight { get => jumpHeight;}
    public Vector3 JumpDiskScale { get => jumpDiskScale; }
}
