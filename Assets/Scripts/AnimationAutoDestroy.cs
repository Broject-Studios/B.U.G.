using UnityEngine;
using System.Collections;

public class AnimationAutoDestroy : MonoBehaviour
{
    public float delay = 0f;
    public Animator anim;

    void Start()
    {
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length + delay);
    }
}