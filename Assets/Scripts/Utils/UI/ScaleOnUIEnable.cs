using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnUIEnable : MonoBehaviour
{
    [SerializeField] private float scalingMultiplier;

    [SerializeField] private bool scaleY, scaleX;

    private void Awake()
    {
        if (scaleX && scaleY)
        {
            this.gameObject.transform.localScale = new Vector3(0, 0, 1);
        }
        else if (scaleY)
        {
            this.gameObject.transform.localScale = new Vector3(1, 0, 1);
        } else if (scaleX)
        {
            this.gameObject.transform.localScale = new Vector3(0, 1, 1);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("ScaleUp");
    }


    IEnumerator ScaleUp()
    {
        while (this.gameObject.transform.localScale.y < 1 || this.gameObject.transform.localScale.x < 1)
        {
            this.gameObject.transform.localScale = Vector3.MoveTowards(this.gameObject.transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * scalingMultiplier);
            yield return null;
        }
    }

}
