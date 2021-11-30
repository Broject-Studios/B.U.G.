using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteFromList : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    private SpriteRenderer sprtRenderer;

    private void Awake()
    {
        sprtRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sprtRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
    }
}
