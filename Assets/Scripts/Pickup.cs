using System;
using UnityEngine;

internal class Pickup : MonoBehaviour
{
    GameManager gm;
    Animator animator;
    static Transform player;

    private void Start()
    {
        gm = GameManager.Instance;
        animator = GetComponentInChildren<Animator>();
        if (!player)
        {
            player = FindObjectOfType<Player>().transform; 
        }
    }

    private void Update()
    {
        if(gm.powerupManager.Magnet.active)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance < gm.powerupManager.Magnet.maxDistance)
            {
                transform.position =
             Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * gm.powerupManager.Magnet.speed); 
            }
        }
    }

    internal void Collect()
    {
        animator.SetTrigger("collect");
        Destroy(gameObject, 0.5f);

    }
}