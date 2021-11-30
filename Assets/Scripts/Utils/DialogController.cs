using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{

    [SerializeField] private TypeWriter typeWriter;

    [SerializeField] private List<string> lines = new List<string>();


    [SerializeField] private List<AudioClip> linesAudio = new List<AudioClip>();

    private int currentLine;

    [SerializeField] private UIManager manager;


    private void Start()
    {
        currentLine = 0;

        typeWriter.OnMessageFinished = NextLine;

        if (linesAudio[currentLine])
        {
            typeWriter.TypeText(lines[currentLine], linesAudio[currentLine]);
        }
        else
        {
            typeWriter.TypeText(lines[currentLine]);
        }

        if (currentLine >= lines.Count - 1)
        {
            if (manager)
            {
                typeWriter.OnMessageFinished = manager.DialogFinished;
            }
        }
    }

    private void NextLine()
    {
        currentLine++;

        typeWriter.ResetTextbox();

        if(linesAudio[currentLine])
        {
            typeWriter.TypeText(lines[currentLine], linesAudio[currentLine]);
        } else
        {
            typeWriter.TypeText(lines[currentLine]);
        }

        if (currentLine >= lines.Count - 1)
        {
            if (manager)
            {
                typeWriter.OnMessageFinished = manager.DialogFinished;
            }
        }
    }

}
