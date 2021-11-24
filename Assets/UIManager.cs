using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject general;

    [SerializeField] private GameObject title;

    [SerializeField] private GameObject launchButton;

    public void DialogFinished()
    {
        general.SetActive(false);
        title.SetActive(true);
        launchButton.SetActive(true);
    }

}
