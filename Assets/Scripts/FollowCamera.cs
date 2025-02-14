using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    private float _offsetX;

    void Start()
    {
        if (target == null) return;

        _offsetX = transform.position.x - target.position.x;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + _offsetX;
        transform.position = pos;
    }
}
