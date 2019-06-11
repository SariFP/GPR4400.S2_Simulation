using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingMushrooms : MonoBehaviour
{
    public GameObject MushroomPrefab;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;
    private int terrainSize = 100;

    private float[,] terrain;
    private float x;
    private float z;

    private Vector3 position;
    private List<Vector3> ExistingMushrooms;
    private List<Vector3> ExistingNeighbors;
    private List<Vector3> OutsideTheBox;
    private List<Vector3> InsideButFree;
    private List<Vector3> hikingPoints;

    private Vector3 hikingPoint;
    private System.Random rand;

    void Start()
    {
        ExistingMushrooms = new List<Vector3>();
        ExistingNeighbors = new List<Vector3>();
        OutsideTheBox = new List<Vector3>();
        hikingPoints = new List<Vector3>();
        terrain = new float[100, 100];
        rand = new System.Random();
        x = rand.Next(xMin, xMax);
        z = rand.Next(zMin, zMax);
        hikingPoint = new Vector3(x, 0, z);
        hikingPoints.Add(hikingPoint);
        StartCoroutine(SentHikingPoint());
    }

    void Update()
    {


        //SentHikingPoint();

    }


    /* private void*/
    IEnumerator SentHikingPoint()
    {
        for (int i = 0; i < 500; i++)
        {
            int q = Random.Range(1, 5);
            Debug.Log("q= " + q);
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
