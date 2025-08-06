using System;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    private float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;
    private float xFollowRange = 3f;
    private float yFollowRange = 0.3f;
    [SerializeField] private Transform target;
    void Update()
    {
        Vector3 targetposition = transform.position;
        if (Math.Abs(transform.position.x-target.position.x)>xFollowRange)
        {
            targetposition.x = target.position.x;
        }
        if (Math.Abs(transform.position.y-target.position.y)>yFollowRange)
        {
            targetposition.y = target.position.y;
        }
        transform.position = Vector3.SmoothDamp(transform.position,targetposition,ref velocity,smoothTime);
    }
}
