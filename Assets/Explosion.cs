using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float minForceX, maxForceX;
    [SerializeField] private float minForceY, maxForceY;

    [SerializeField] private AudioClip explosionAudio;

    private void OnEnable()
    {
        if(explosionAudio)
        {
            AudioSource.PlayClipAtPoint(explosionAudio, this.transform.position);
        }
    }

    public void ThrowParticles (List<GameObject> particles)
    {
        for (int i = 0; i < particles.Count; i++)
        {
            GameObject particle = Instantiate(particles[i], this.transform.position, Quaternion.identity);
            particle.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(minForceX, maxForceX), Random.Range(minForceY, maxForceY)), ForceMode2D.Impulse);
        }
    }

}
