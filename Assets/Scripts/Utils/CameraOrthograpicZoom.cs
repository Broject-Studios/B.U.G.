using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrthograpicZoom : MonoBehaviour
{
    [SerializeField] private Vector2 ratio;

    [SerializeField] private SpriteRenderer bg;

    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = bg.bounds.size.x / bg.bounds.size.y; //ratio.x / ratio.y;

        Camera.main.orthographicSize = bg.bounds.size.x * Screen.height / Screen.width * 0.5f;

        if(screenRatio >= targetRatio)
        {
            // Camera.main.orthographicSize = bg.bounds.size.y /*ratio.y*/ / 2;
        } else
        {
            float difference = targetRatio / screenRatio;
            //Camera.main.orthographicSize = bg.bounds.size.y /*ratio.y*/ / 2 * difference;
        }
    }

}
