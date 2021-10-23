using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 startPosition;
    public Vector3 endPosition;

    private void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(10, 0, 0);
    }

    private void Update()
    {
        if(transform.position.x > endPosition.x || transform.position.x < startPosition.x)
        {
            speed *= -1;
        }
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
    }
}