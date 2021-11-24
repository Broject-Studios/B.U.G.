using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private float dropSpeed;


    void Update()
    {
        transform.position = new Vector3(transform.position.x, 
            transform.position.y - (dropSpeed * Time.deltaTime), 
            transform.position.z);
    }
}
