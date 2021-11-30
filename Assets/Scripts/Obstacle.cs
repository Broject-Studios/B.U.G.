using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private bool destroyOnHit;

    [SerializeField] private AudioClip hitSound;

    [SerializeField] private GameObject onDestroyObject;

    [SerializeField] private List<GameObject> particles;

    public void OnHit ()
    {
        if (destroyOnHit)
        {

            if(hitSound)
            {
                AudioSource.PlayClipAtPoint(hitSound, this.transform.position);
            }

            if(onDestroyObject)
            {
                GameObject obj = Instantiate(onDestroyObject, this.transform.position, Quaternion.identity);
                obj.GetComponent<Explosion>().ThrowParticles(particles);
            }

            Destroy(this.gameObject);
        }
    }

}
