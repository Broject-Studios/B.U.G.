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
        Camera.main.GetComponent<CameraShake>().Shake(0.05f, 0.001f);

        if (destroyOnHit)
        {

            if(hitSound)
            {
                Play2DClipAtPoint(hitSound);
            }

            if(onDestroyObject)
            {
                GameObject obj = Instantiate(onDestroyObject, this.transform.position, Quaternion.identity);
                obj.GetComponent<Explosion>().ThrowParticles(particles);
            }

            Destroy(this.gameObject);
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
