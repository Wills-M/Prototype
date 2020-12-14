using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform followingCamera;
    private Vector3 offset;

    private void Start()
    {
        SetOffset();
    }

    private void Update()
    {
        followingCamera.position = transform.position + offset;
    }

    private void SetOffset()
    {
        offset = followingCamera.position - transform.position;
    }
}
