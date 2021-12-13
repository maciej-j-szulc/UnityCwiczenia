using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skrzynia2 : MonoBehaviour
{

    public float speed = 100.0f;
    Rigidbody rb;
    bool back = true;
    bool left = true;
    public GameObject kostka;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {

        if ((transform.position.x >= 10) && (transform.position.z >= 10))
        {
            back = false;
            left = false;
            kostka.transform.Rotate(0, -90, 0, Space.World);
        }
        else if ((transform.position.x <= 0) && (transform.position.z <= 0))
        {
            back = true;
            left = true;
            kostka.transform.Rotate(0, -90, 0, Space.World);
        }
        else if ((transform.position.x >= 10) && (transform.position.z <= 0))
        {
            back = false;
            left = true;
            kostka.transform.Rotate(0, -90, 0, Space.World);
        }
        else if ((transform.position.x <= 0) && (transform.position.z >= 10))
        {
            back = true;
            left = false;
            kostka.transform.Rotate(0, -90, 0, Space.World);
        }

        if (back&&left)
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if(!back&&left)
        {
            transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);
        }
        else if(!back&&!left)
        {
            transform.position = transform.position - new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position = transform.position - new Vector3(0, 0, speed * Time.deltaTime);
        }
    }
}