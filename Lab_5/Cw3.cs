using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 12f;
    private bool isRunningForward = true;
    private bool isRunningBackwards = false;
    private float startPosition;
    private float endPosition;
    public List<Vector3> punkty;
    private Vector3 poczatek_kolejki;
    private Vector3 koniec_kolejki;
    private int index = 2;
    private bool reverse = false;

    void Start()
    {
        endPosition = transform.position.z + distance;
        startPosition = transform.position.z;
    }

    void Update()
    {
        if (isRunningForward && transform.position.z >= endPosition)
        {
            isRunning = false;
        }
        else if (isRunningBackwards && transform.position.z <= startPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }

        if (isRunning)
        {
            if (Vector3.Distance(transform.position, koniec_kolejki) <= 0.1f)
            {
                isRunning = false;
                if (index < punkty.Count)
                {
                    poczatek_kolejki = koniec_kolejki;
                    koniec_kolejki = punkty[index];
                    index++;
                    isRunning = true;
                }
                else
                {
                    isRunning = false;
                    if (reverse == false)
                    {
                        punkty.Reverse();
                        poczatek_kolejki = punkty[0];
                        koniec_kolejki = punkty[1];
                        index = 2;
                        reverse = true;
                        isRunning = true;
                    }
                    else
                    {
                        punkty.Reverse();
                        poczatek_kolejki = punkty[0];
                        koniec_kolejki = punkty[1];
                        index = 2;
                        isRunning = false;
                        reverse = false;
                    }
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            // zapamiętujemy "starego rodzica"
            // skrypt przypisany do windy, ale other może być innym obiektem
            other.gameObject.transform.parent = transform;

            if (transform.position.z >= endPosition)
            {
                isRunningBackwards = true;
                isRunningForward = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= startPosition)
            {
                isRunningForward = true;
                isRunningBackwards = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = null;
        }
    }
}