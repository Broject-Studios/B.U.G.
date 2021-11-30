using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject background;

    [SerializeField] private List<GameObject> clouds = new List<GameObject>();

    [SerializeField] private float min;
    [SerializeField] private float max;

    [SerializeField] private float spawnDelay;

    [SerializeField] private float cloudStopY;


    private void OnEnable()
    {
        StartCoroutine("DropClouds");
    }

    // Update is called once per frame
    void Update()
    {
        if (background.transform.position.y < cloudStopY)
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator DropClouds()
    {
        while (true)
        {
            GameObject.Instantiate(clouds[Random.Range(0, clouds.Count)], new Vector3(Random.Range(min, max), transform.position.y, 0), Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
