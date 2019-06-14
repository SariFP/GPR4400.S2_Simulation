using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject Player;
    public GameObject Rabbit;
    public GameObject Fireflies;
    public GameObject FogParticle;
    public GameObject[] Waypoint;
    Terrain terrain;

    private float terrainHeight;
    public RaycastHit hit;
    public LayerMask terrainLayer;


    public int width = 256;
    public int height = 256;

    //BUMPINESSWERTE:
    private int depth = (int)SimulationManager.Instance.Bumpiness;
    private float scale = SimulationManager.Instance.Bumpiness;

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
        for (int i = 0; i < Waypoint.Length; i++)
        {
            if (Physics.Raycast(new Vector3(Waypoint[i].transform.position.x, 100, Waypoint[i].transform.position.z), Vector3.down, out hit, Mathf.Infinity, terrainLayer))
            {
                terrainHeight = hit.point.y;
                Waypoint[i].transform.position = new Vector3(Waypoint[i].transform.position.x, terrainHeight, Waypoint[i].transform.position.z);
            }
        }
        if (Physics.Raycast(new Vector3(Player.transform.position.x, 100, Player.transform.position.z), Vector3.down, out hit, Mathf.Infinity, terrainLayer))
        {
            terrainHeight = hit.point.y;
            Player.transform.position = new Vector3(Player.transform.position.x, terrainHeight, Player.transform.position.z);
            Fireflies.transform.position = new Vector3(Fireflies.transform.position.x, terrainHeight, Fireflies.transform.position.z);
            FogParticle.transform.position = new Vector3(FogParticle.transform.position.x, terrainHeight, FogParticle.transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(new Vector3(Rabbit.transform.position.x, 100, Rabbit.transform.position.z), Vector3.down, out hit, Mathf.Infinity, terrainLayer))
        {
            terrainHeight = hit.point.y;
            Rabbit.transform.position = new Vector3(Rabbit.transform.position.x, terrainHeight, Rabbit.transform.position.z);
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
