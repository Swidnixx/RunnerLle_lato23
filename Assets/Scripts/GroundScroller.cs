using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer tile1, tile2;
    float speed;

    private void FixedUpdate()
    {
        speed = GameManager.Instance.worldSpeed;

        Vector3 move = new Vector3(-speed, 0, 0);
        tile1.transform.Translate(move);
        tile2.transform.Translate(move);

        if(tile2.transform.position.x < 0)
        {
            tile1.transform.position = tile2.transform.position 
                + new Vector3(tile1.bounds.size.x, 0, 0);

            var tmp = tile1;
            tile1 = tile2;
            tile2 = tmp;
        }
    }
}
