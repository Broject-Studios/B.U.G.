using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject background;

    [SerializeField] private List<GameObject> obstaclesStageOne = new List<GameObject>();

    [SerializeField] private float stageOneOffY;
    [SerializeField] private float stageTwoStartY;

    [SerializeField] private List<GameObject> obstaclesStageTwo = new List<GameObject>();

    [SerializeField] private float min;
    [SerializeField] private float max;

    [SerializeField] private float spawnDelay;

    private bool stageOne = false;
    private bool stageTwo = false;

    private void OnEnable()
    {
        StartCoroutine("DropObstaclesStageOne");
        stageOne = true;
    }


    private void Update()
    {
        if (background.transform.position.y < stageOneOffY && stageOne)
        {
            stageOne = false;
            StopCoroutine("DropObstaclesStageOne");
        }

        if (background.transform.position.y < stageTwoStartY && !stageTwo)
        {
            stageTwo = true;
            StartCoroutine("DropObstaclesStageTwo");
        }
    }


    IEnumerator DropObstaclesStageOne()
    {
        while(true)
        {
            GameObject.Instantiate(obstaclesStageOne[Random.Range(0, obstaclesStageOne.Count)], new Vector3(Random.Range(min, max), transform.position.y, 0), Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    IEnumerator DropObstaclesStageTwo()
    {
        while(true)
        {
            GameObject.Instantiate(obstaclesStageTwo[Random.Range(0, obstaclesStageTwo.Count)], new Vector3(Random.Range(min, max), transform.position.y, 0), Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

}
