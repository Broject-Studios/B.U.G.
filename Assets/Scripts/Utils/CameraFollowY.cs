using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowY : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float smoothFactor;
    [SerializeField] private Vector3 offset;

    private bool launched = false;

    private void FixedUpdate ()
    {
        if (launched)
        {
            Vector3 desiredPosition = new Vector3(0 + offset.x, target.position.y + offset.y, target.position.z + offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothFactor);
            transform.position = smoothedPosition;
        }
    }

    public void Launch ()
    {
        launched = true;
    }
}
