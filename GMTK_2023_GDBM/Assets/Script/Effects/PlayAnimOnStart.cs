using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnStart : MonoBehaviour
{
    Animator animator;
    [SerializeField] string anim;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.Play(anim);
    }

    public void PlayAnim()
    {
        animator.Play(anim);
    }
}
