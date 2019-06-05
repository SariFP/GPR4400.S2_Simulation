using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadTrees : MonoBehaviour
{
    public GameObject TreeSpawnerPrefab;
    public GameObject GemSpawnerPrefab;

    private Terrain Terrain;
    private int terrainSize = 500;
    private Vector3 position;
    private int[,] terrain;



    // Start is called before the first frame update
    void Start()
    {
        terrain = new int[500,500];
        Terrain = GetComponent<Terrain>();
        //terrainSize = Terrain.terrainData.size;
        SpreadObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpreadObjects()
    {
        System.Random rand = new System.Random();
        for (int x = 0; x < terrainSize; x++)
        {
            for (int y = 0; y < terrainSize; y++)
            {
                terrain[x, y] = rand.Next(5); // Set a random type between 1 - 4
            }
        }

        for (int x = 0; x < terrainSize; x++)
        {
            for (int y = 0; y < terrainSize; y++)
            {
                if (terrain[x, y] == 2)
                {
                    position = new Vector3(x, 0, y);
                    Instantiate(TreeSpawnerPrefab, position, Quaternion.identity);
                }
                if (terrain[x, y] == 1)
                {
                    position = new Vector3(x, 0, y);
                    Instantiate(GemSpawnerPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
