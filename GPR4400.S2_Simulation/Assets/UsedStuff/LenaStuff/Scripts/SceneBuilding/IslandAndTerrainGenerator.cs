using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandAndTerrainGenerator : MonoBehaviour
{
    //BUMPINESSWERTE:
    public float Depth = 10;
    public float Scale = 20;
    public float middleDepthScale = 30;

    //WIDENESS:
    public float Kx = 60;
    public float Ky = 60;

    //Randomize offset
    [SerializeField]
    private float offsetX = 200f;
    [SerializeField]
    public float offsetY = 200f;

    public LayerMask TerrainLayer;

    private Terrain terrain;
    public Terrain RenderTerrain;
    private int width = 256;
    private int height = 256;
    private float[,] heights;
    private RaycastHit hit;
    private float miniCoast = 0.05f;
    private float maxiCoast = 100;

    private void Awake()
    {
        terrain = GetComponent<Terrain>();
        height = terrain.terrainData.heightmapHeight;
        width = terrain.terrainData.heightmapWidth;
        heights = new float[width, height];
        middleDepthScale = SimulationManager.Instance.Bumpiness;
        Scale = middleDepthScale / 3 * 2;
        Depth = middleDepthScale / 3;
        Kx = SimulationManager.Instance.Wideness;
        Ky = SimulationManager.Instance.Wideness;
        offsetX = Random.Range(0f, 1000f);
        offsetY = Random.Range(0f, 1000f);
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        RenderTerrain.terrainData = terrain.terrainData;
        ResetSeaFloor();
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = (int)width + 1;
        terrainData.size = new Vector3(width, Depth, height);
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
        float x0 = Mathf.Abs(x - width / 2);
        float y0 = Mathf.Abs(y - height / 2);
        float hParaboloid = 1 - (Mathf.Pow(x0 / Kx, 2) + Mathf.Pow(y0 / Ky, 2));
        float xCoord = (float)x / width * Scale + offsetX;
        float yCoord = (float)y / height * Scale + offsetY;
        float h = Mathf.PerlinNoise(xCoord, yCoord);
        h += hParaboloid;
        float calcY = h / 2;

        if (calcY > miniCoast)
        {
            float maxiCoastTemp = calcY;

            if (maxiCoastTemp < maxiCoast)
            {
                maxiCoast = maxiCoastTemp;
            }
        }
        return calcY;
    }

    public void ResetSeaFloor()
    {
        SimulationManager.Instance.Ground = maxiCoast;
        SimulationManager.Instance.TerrainGenerated = true;
    }
}
