using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float maxY = 1.2f;
    public float minY = -1.2f;

    float minSize = 0.5f;
    float maxSize = 4f; 

    public Transform top;
    public Transform bottom;

    public float widthPadding = 4f;

    public Vector2 SetRandomPlace(Vector2 lastPos, int count)
    {
        top.localPosition = new Vector2(0, Random.Range(minSize, maxSize) / 2);
        bottom.localPosition = new Vector2(0, -Random.Range(minSize, maxSize) / 2);

        Vector2 pos = lastPos + new Vector2(widthPadding, 0);
        pos.y = Random.Range(minY, maxY);

        transform.position = pos;

        return pos;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            GameManager.Instance.AddScore(1);
        }
    }
}
