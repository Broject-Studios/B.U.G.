using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> obstaclesStageOne = new List<GameObject>();
    [SerializeField] private List<GameObject> obstaclesStageTwo = new List<GameObject>();

    [SerializeField] private float min;
    [SerializeField] private float max;

    [SerializeField] private float spawnDelay;

    private void OnEnable()
    {
        StartCoroutine("DropObstaclesStageOne");
    }


    IEnumerator DropObstaclesStageOne()
    {
        while(true)
        {
            GameObject.Instantiate(obstaclesStageOne[Random.Range(0, obstaclesStageOne.Count)], new Vector3(Random.Range(min, max), transform.position.y, 0), Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

}
