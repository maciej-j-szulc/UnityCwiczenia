using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 1.0f;
    int objectCounter = 0;
    public int iloscObiektow = 0;
    // obiekt do generowania
    public GameObject block;
    public Collider podloga;
    public Material zolty;
    public Material czarny;
    public Material zielony;
    public Material czerwony;
    public Material niebieski;

    void Start()
    {
        podloga = GetComponent<Collider>();
        int maxX = (int)podloga.bounds.max.x;
        int minX = (int)podloga.bounds.min.x;
        int maxZ = (int)podloga.bounds.max.z;
        int minZ = (int)podloga.bounds.min.z;

        System.Random r = new System.Random();


        for (int i = 0; i < iloscObiektow; i++)
        {
            this.positions.Add(new Vector3(r.Next(minX,maxX), 5, r.Next(minZ,maxZ)));
        }
        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        //Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
                GameObject Box = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            System.Random r = new System.Random();
            int randomNumber = r.Next(1, 6);
            switch(randomNumber)
            {
                case 1:
                    Box.transform.GetComponent<Renderer>().material = zolty;
                    break;
                case 2:
                    Box.transform.GetComponent<Renderer>().material = czerwony;
                    break;
                case 3:
                    Box.transform.GetComponent<Renderer>().material = czarny;
                    break;
                case 4:
                    Box.transform.GetComponent<Renderer>().material = zielony;
                    break;
                case 5:
                    Box.transform.GetComponent<Renderer>().material = niebieski;
                    break;
            }
                


                yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}