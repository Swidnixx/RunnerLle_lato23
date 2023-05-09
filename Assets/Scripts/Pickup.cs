using System;
using UnityEngine;

internal class Pickup : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    internal void Collect()
    {
        animator.SetTrigger("collect");
        Destroy(gameObject, 0.5f);
    }
}