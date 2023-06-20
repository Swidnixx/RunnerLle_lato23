using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SoundManager.Instance.PlayMagnet();
            Destroy(gameObject);
            GameManager.Instance.ActivateMagnet();
        }
    }
}
