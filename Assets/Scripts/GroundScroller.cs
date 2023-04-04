using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer tile1, tile2;
    public SpriteRenderer[] tilePrefabs;
    float speed;

    private void FixedUpdate()
    {
        speed = GameManager.Instance.worldSpeed;

        Vector3 move = new Vector3(-speed, 0, 0);
        tile1.transform.Translate(move);
        tile2.transform.Translate(move);

        if(tile2.transform.position.x < 0)
        {
            int index = Random.Range(0, tilePrefabs.Length);

            SpriteRenderer newTile = Instantiate(tilePrefabs[index], transform);

            Vector3 position = tile2.transform.position
                 + new Vector3(tile2.bounds.size.x / 2, 0, 0)
                 + new Vector3(newTile.bounds.size.x / 2, 0, 0);

            newTile.transform.position = position;

            Destroy(tile1.gameObject);
            tile1 = tile2;
            tile2 = newTile;
        }
    }
}
