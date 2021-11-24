using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{

    [SerializeField] private TypeWriter typeWriter;

    [SerializeField] private List<string> lines = new List<string>();

    private int currentLine;

    [SerializeField] private UIManager manager;


    private void Start()
    {
        currentLine = 0;

        typeWriter.OnMessageFinished = NextLine;

        typeWriter.TypeText(lines[currentLine]);
    }

    private void NextLine()
    {
        currentLine++;

        typeWriter.ResetTextbox();

        typeWriter.TypeText(lines[currentLine]);

        if (currentLine >= lines.Count - 1)
        {
            typeWriter.OnMessageFinished = manager.DialogFinished;
        }
    }

}
