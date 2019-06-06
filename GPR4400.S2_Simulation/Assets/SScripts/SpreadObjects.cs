using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadObjects : MonoBehaviour
{
    public GameObject TreeSpawnerPrefab;
    public GameObject GemSpawnerPrefab;

    //public Terrain Terrain;
    private int terrainSize = 1000;
    private Vector3 position;
    private int[,] terrain;


    void Start()
    {
        terrain = new int[1000, 1000];
        //Terrain = GetComponent<Terrain>();
        //terrainSize = Terrain.terrainData.size;
        SpreadObjs();
    }



    private void SpreadObjs()
    {
        System.Random rand = new System.Random();
        for (int x = 0; x < terrainSize; x++)
        {
            for (int y = 0; y < terrainSize; y++)
            {
                terrain[x, y] = rand.Next(100);
            }
        }

        StartCoroutine(InstantiateObjs());
    }

    IEnumerator InstantiateObjs()
    { 
        for (int x = 0; x < terrainSize; x++)
        {
            for (int y = 0; y < terrainSize; y++)
            {
                if (terrain[x, y] == 14)
                {
                    position = new Vector3(x - 500, 0, y - 500);
                    Instantiate(TreeSpawnerPrefab, position, Quaternion.identity);
                }
                if (terrain[x, y] == 26)
                {
                    position = new Vector3(x - 500, 0, y - 500);
                    Instantiate(GemSpawnerPrefab, position, Quaternion.identity);
                }

                yield return new WaitForSeconds(1);
            }
        }
    }
}
