using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalityBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SoundManager.Instance.PlayBattery();
            Destroy(gameObject);
            GameManager.Instance.ActivateImmortality();
        }
    }
}
