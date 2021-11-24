using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] private AudioClip hitSound;

    [SerializeField] private bool destroyOnHit;


    public void OnHit ()
    {
        if(destroyOnHit)
        {
            Destroy(this.gameObject);
        }
    }

}
