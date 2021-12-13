using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door;
    private int counter = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(counter == 0)
            {
                Debug.Log("Wykryto kolizję");
                door.Rotate(Vector3.up * 90);
                counter=1;
            }
            else
            {
                Debug.Log("Wykryto kolizję");
                door.Rotate(Vector3.up * -90);
                counter=0;
            }
        }
    }
}
