using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float maxY = 1f;
    public float minY = -1f;

    public float minSize = 1f;
    public float maxSize = 3f; 

    public Transform top;
    public Transform bottom;

    public float widthPadding = 4f;

    public Vector2 SetRandomPlace(Vector2 lastPos, int count)
    {
        float size = Random.Range(minSize, maxSize);
        float halfSize = size / 2;

        top.localPosition = new Vector2(0, halfSize);
        bottom.localPosition = new Vector2(0, -halfSize);

        Vector2 pos = lastPos + new Vector2(widthPadding, 0);

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
