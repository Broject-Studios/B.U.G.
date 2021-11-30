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
            Play2DClipAtPoint(explosionAudio);
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


    public void Play2DClipAtPoint(AudioClip clip)
    {
        //  Create a temporary audio source object
        GameObject tempAudioSource = new GameObject("TempAudio");

        //  Add an audio source
        AudioSource audioSource = tempAudioSource.AddComponent<AudioSource>();

        //  Add the clip to the audio source
        audioSource.clip = clip;

        //  Set the volume
        audioSource.volume = 1;

        //  Set properties so it's 2D sound
        audioSource.spatialBlend = 0.0f;

        //  Play the audio
        audioSource.Play();

        //  Set it to self destroy
        Destroy(tempAudioSource, clip.length);

    }
}
