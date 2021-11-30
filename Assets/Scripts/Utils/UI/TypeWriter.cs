using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class TypeWriter : MonoBehaviour
{

	public Text textComp;

	public string message;
	public AudioClip speechAudio;

	public float typeDelay;
	public float playDelay;
	public float finishDelay;

	public Action OnMessageFinished = delegate { };

	void Start()
	{
		textComp = GetComponent<Text>();
	}

	public void TypeText(string txt, AudioClip audio = null)
    {
		message = txt;
		if (audio)
        {
			speechAudio = audio;
		}
		StartCoroutine("PlayText");
    }

	public void ResetTextbox()
    {
		textComp.text = "";
    }

	IEnumerator PlayText()
	{
		yield return new WaitForSeconds(playDelay);

		Play2DClipAtPoint(speechAudio);

		foreach (char c in message)
		{
			textComp.text += c;
			yield return new WaitForSeconds(typeDelay);
		}

		yield return new WaitForSeconds(finishDelay);

		OnMessageFinished();
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