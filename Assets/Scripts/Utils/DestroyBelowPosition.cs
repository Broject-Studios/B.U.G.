using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBelowPosition : MonoBehaviour
{
    [SerializeField] private bool destroyBelowX;
    [SerializeField] private bool destroyBelowY;

    [SerializeField] private float boundaryX;
    [SerializeField] private float boundaryY;

    private void FixedUpdate()
    {
        if (destroyBelowX && transform.position.x <= boundaryX)
        {
            Destroy(this.gameObject);
        }
        if (destroyBelowY && transform.position.y <= boundaryY)
        {
            Destroy(this.gameObject);
        }
    }
}
