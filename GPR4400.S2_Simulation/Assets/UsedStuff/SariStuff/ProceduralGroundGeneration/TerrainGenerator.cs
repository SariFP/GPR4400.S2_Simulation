using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject Player;
    Terrain terrain;

    public int depth = 5;

    private float width;
    private float height;

    public float scale = 5f;

    private float[,] heights;
    private float terrainHeight;

    public RaycastHit hit;
    public LayerMask terrainLayer;

    //Randomize offset
    public float offsetX = 100f;
    public float offsetY = 100f;

    private void Awake()
    {
        offsetX = Random.Range(0f, 1000f);
        offsetY = Random.Range(0f, 1000f);

        terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        terrainHeight = terrain.terrainData.size.y;
        width = terrain.terrainData.size.x;
        height = terrain.terrainData.size.z;
    }

    private void Start()
    {
        if (Physics.Raycast(new Vector3(0, 100, 0), Vector3.down, out hit, Mathf.Infinity, terrainLayer))
        {
            terrainHeight = hit.point.y;
            Player.transform.Translate(Player.transform.position.x, terrainHeight, Player.transform.position.z);
        }
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = (int)width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights()
    {
        heights = new float[(int)width, (int)height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
