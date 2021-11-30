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
    }
}
