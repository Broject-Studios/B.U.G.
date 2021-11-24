using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// attach to UI Text component (with the full text already there)

public class TypeWriter : MonoBehaviour
{

	public Text textComp;

	public string message;

	public float typeDelay;
	public float playDelay;
	public float finishDelay;

	public Action OnMessageFinished = delegate { };


	void Start()
	{
		textComp = GetComponent<Text>();
	}

	public void TypeText(string txt)
    {
		message = txt;
		StartCoroutine("PlayText");
    }

	public void ResetTextbox()
    {
		textComp.text = "";
    }

	IEnumerator PlayText()
	{
		yield return new WaitForSeconds(playDelay);

		foreach (char c in message)
		{
			textComp.text += c;
			yield return new WaitForSeconds(typeDelay);
		}

		yield return new WaitForSeconds(finishDelay);

		OnMessageFinished();
	}

}