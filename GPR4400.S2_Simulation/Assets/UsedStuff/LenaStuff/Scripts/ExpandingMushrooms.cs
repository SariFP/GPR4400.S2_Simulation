using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingMushrooms : MonoBehaviour
{
    public int AmountOfMushrooms = 500;
    public GameObject MushroomPrefab;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;

    private float x;
    private float z;
    private Vector3 hikingPoint;

    void Start()
    {
        x = Random.Range(xMin, xMax);
        z = Random.Range(zMin, zMax);
        hikingPoint = new Vector3(x, 0, z);
        StartCoroutine(SentHikingPoint());
    }


    IEnumerator SentHikingPoint()
    {
        for (int i = 0; i < AmountOfMushrooms; i++)
        {
            int q = Random.Range(1, 5);
            if (q == 1)
            {
                hikingPoint += new Vector3(0.2f, 0, 0);
                Instantiate(MushroomPrefab, hikingPoint, Quaternion.identity);
            }
            else if (q == 2)
            {
                hikingPoint += new Vector3(0, 0, -0.2f);
                Instantiate(MushroomPrefab, hikingPoint, Quaternion.identity);
            }
            else if (q == 3)
            {
                hikingPoint += new Vector3(-0.2f, 0, 0);
                Instantiate(MushroomPrefab, hikingPoint, Quaternion.identity);
            }
            else if (q == 4)
            {
                hikingPoint += new Vector3(0, 0, 0.2f);
                Instantiate(MushroomPrefab, hikingPoint, Quaternion.identity);
            }

            yield return new WaitForSeconds(.5f);
        }
    }
}
