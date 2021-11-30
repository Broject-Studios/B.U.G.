using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{

    [SerializeField] private float endPosY;
    [SerializeField] private float dropSpeed;

    [SerializeField] private GameObject deadGuy;
    [SerializeField] private GameObject explosions;

    [SerializeField] private GameManager manager;

    [SerializeField] private AudioClip crashAudio;

    private void OnEnable()
    {
        StartCoroutine("DropTheMoon");
    }


    IEnumerator DropTheMoon()
    {
        while(this.transform.position.y > endPosY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - dropSpeed, transform.position.z);

            yield return null;
        }

        OnMoonDropped();
    }

    void OnMoonDropped()
    {
        deadGuy.SetActive(true);
        explosions.SetActive(true);

        manager.GameWin();

        Play2DClipAtPoint(crashAudio);

        Camera.main.GetComponent<CameraShake>().Shake(0.1f, 0.00025f);
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
