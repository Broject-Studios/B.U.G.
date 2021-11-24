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
    [SerializeField] private Drop[] thingsToDrop;

    public void Launch()
    {
        rocket.enabled = true;
        for (int i = 0; i < thingsToDrop.Length; i++)
        {
            thingsToDrop[i].enabled = true;
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

    }
}
