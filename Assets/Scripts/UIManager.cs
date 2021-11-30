using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject[] enableOnDialogFinished;
    [SerializeField] private GameObject[] disableOnDialogFinished;


    public void DialogFinished()
    {
        for (int i = 0; i < enableOnDialogFinished.Length; i++)
        {
            enableOnDialogFinished[i].SetActive(true);
        }

        for (int i = 0; i < disableOnDialogFinished.Length; i++)
        {
            disableOnDialogFinished[i].SetActive(false);
        }
    }



}
