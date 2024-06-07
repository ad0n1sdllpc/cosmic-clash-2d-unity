using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 startpos;

    void Start()
    {
        startpos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * speed, 20);
        transform.position = startpos + Vector3.left * newPos;
    }
}
