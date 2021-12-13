using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 200f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseXMove);

        if(transform.rotation.x > 0.5f || transform.rotation.x < -0.5f)
        {
            transform.Rotate(new Vector3(mouseYMove, 0f, 0f), Space.Self);
        }
        else
        {
            transform.Rotate(new Vector3(-mouseYMove, 0f, 0f), Space.Self);
        }

    }
}