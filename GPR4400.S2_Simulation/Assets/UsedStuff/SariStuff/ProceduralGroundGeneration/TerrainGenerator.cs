using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] Waypoint;
    public GameObject Rabbit;
    Terrain terrain;

    private float terrainHeight;
    public RaycastHit hit;
    public LayerMask terrainLayer;

    public int depth = 5;
    public int width = 256;
    public int height = 256;
    public float scale = 5f;

    //Randomize offset
    [SerializeField]
    private float offsetX = 100f;
    [SerializeField]
    private float offsetY = 100f;

    private void Awake()
    {
        Waypoint = GameObject.FindGameObjectsWithTag("waypoint");

        offsetX = Random.Range(0f, 1000f);
        offsetY = Random.Range(0f, 1000f);

        terrain = GetComponentInParent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        terrainHeight = terrain.terrainData.size.y;
    }

    private void Start()
    {
        foreach (GameObject item in Waypoint)
        {
            if (Physics.Raycast(new Vector3(0, 100, 0), Vector3.down, out hit, Mathf.Infinity, terrainLayer))
            {
                terrainHeight = hit.point.y;
                item.transform.Translate(item.transform.position.x, terrainHeight, item.transform.position.z);
            }
        }
        if (Physics.Raycast(new Vector3(0, 100, 0), Vector3.down, out hit, Mathf.Infinity, terrainLayer))
        {
            terrainHeight = hit.point.y;
            Player.transform.Translate(Player.transform.position.x, terrainHeight, Player.transform.position.z);
            Rabbit.transform.Translate(Rabbit.transform.position.x, terrainHeight, Rabbit.transform.position.z);
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
        float[,] heights = new float[(int)width, (int)height];

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
