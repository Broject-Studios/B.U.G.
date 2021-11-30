using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject moon;
    [SerializeField] private GameObject background;
    [SerializeField] private float endPosition;

    private bool gameEnded = false;

    [SerializeField] private Rocket rocket;
    [SerializeField] private Drop[] dropOnLaunch;

    [SerializeField] private GameObject[] activateOnLaunch;

    [SerializeField] private GameObject spawner;

    [SerializeField] private GameObject gameWinUI;


    public void Launch()
    {
        rocket.enabled = true;
        for (int i = 0; i < dropOnLaunch.Length; i++)
        {
            dropOnLaunch[i].enabled = true;
        }

        for (int j = 0; j < activateOnLaunch.Length; j++)
        {
            activateOnLaunch[j].SetActive(true);
        }
    }

    private void Update()
    {
        if (background.transform.position.y <= endPosition && !gameEnded)
        {
            gameEnded = true;
            EndGame();
        }
    }

    void EndGame()
    {
        background.GetComponent<Drop>().enabled = false;
        moon.SetActive(true);
        spawner.SetActive(false);
    }

    public void GameWin()
    {
        rocket.gameObject.SetActive(false);
        gameWinUI.SetActive(true);
    }

    public void GameOver()
    {

    }
}
