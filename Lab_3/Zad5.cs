using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour
{
    public GameObject block;
    public int ilosc;

    void Start()
    {
        var randomPosition = new System.Random();
        List<Vector3> miejsca = new List<Vector3>();

        for(int i=0;i<10;i++)
        {
            for(int j = 0;j<10;j++)
            {
                miejsca.Add(new Vector3(i, 0, j));
            }
        }

        for(int i = 0;i<ilosc;i++)
        {

            int polozenie = randomPosition.Next(miejsca.Count);
            Instantiate(block, miejsca[polozenie],Quaternion.identity);
            miejsca.RemoveAt(polozenie);
        }

    }
}
