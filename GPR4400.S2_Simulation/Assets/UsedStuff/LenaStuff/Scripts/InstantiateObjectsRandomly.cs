using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectsRandomly : MonoBehaviour
{
    public GameObject TreePrefab;
    public GameObject PlenteousTreePrefeab;
    public GameObject BushPrefab;
    public GameObject PinkSingleXtalPrefab;
    public GameObject GreenSingleXtalPrefab;
    public GameObject BlueSingleXtalPrefab;
    public GameObject PinkGroupXtalPrefab;
    public GameObject YellowGroupXtalPrefab;

    public Terrain Terrain;
    public LayerMask TerrainLayer;

    private float minusOfTotalTerrainRadius; /*WIDENESS*/
    private float amountOfObjects; /*DENSITY*/
    private float speedOfEvolution; /*CELERITY*/

    private float TerrainXMin;
    private float TerrainXMax;
    private float TerrainZMin;
    private float TerrainZMax;
    private float TerrainWidth;
    private float TerrainLength;
    private float TerrainHeight;
    private float deviance = 0.05f;

    private RaycastHit hit;
    private GameObject randomPrefab;
    private Quaternion randomQuat;
    private Vector3 randomPos;
    private float randomPosX;
    private float randomPosZ;
    private float randomPosY;

    void Start()
    {
        minusOfTotalTerrainRadius = SimulationManager.Instance.Wideness;
        amountOfObjects = SimulationManager.Instance.Density;

        speedOfEvolution = SimulationManager.Instance.Celerity;


        TerrainXMin = Terrain.transform.position.x + minusOfTotalTerrainRadius;
        TerrainZMin = Terrain.transform.position.z + minusOfTotalTerrainRadius;
        TerrainWidth = Terrain.terrainData.size.x - minusOfTotalTerrainRadius * 2;
        TerrainLength = Terrain.terrainData.size.z - minusOfTotalTerrainRadius * 2;
        TerrainHeight = Terrain.terrainData.size.y;
        TerrainXMax = TerrainXMin + TerrainWidth;
        TerrainZMax = TerrainZMin + TerrainLength;

        StartCoroutine(FindRandomPositions());
    }


    IEnumerator FindRandomPositions()
    {
        for (int i = 0; i < amountOfObjects; i++)
        {
            randomPosX = Random.Range(TerrainXMin, TerrainXMax);
            randomPosZ = Random.Range(TerrainZMin, TerrainZMax);
            if (Physics.Raycast(new Vector3(randomPosX, 100, randomPosZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
            {
                TerrainHeight = hit.point.y;
            }
            randomPosY = TerrainHeight - deviance;
            randomPos = new Vector3(randomPosX, randomPosY, randomPosZ);

            int randPref = Random.Range(1, 8);

            switch (randPref)
            {
                case 1:
                    randomPrefab = TreePrefab;
                    break;
                case 2:
                    randomPrefab = PlenteousTreePrefeab;
                    break;
                case 3:
                    randomPrefab = BushPrefab;
                    break;
                case 4:
                    randomPrefab = YellowGroupXtalPrefab;
                    break;
                case 5:
                    randomPrefab = PinkGroupXtalPrefab;
                    break;
                case 6:
                    randomPrefab = BlueSingleXtalPrefab;
                    break;
                case 7:
                    randomPrefab = GreenSingleXtalPrefab;
                    break;
                case 8:
                    randomPrefab = PinkSingleXtalPrefab;
                    break;
                default:
                    break;
            }

            int u = Random.Range(-30, 30);
            int w = Random.Range(0, 360);
            int v = Random.Range(-30, 30);

            if (randPref < 6)
            {
                randomQuat = new Quaternion(0, w, 0, 1);
            }
            else
            {
                randomQuat = new Quaternion(u, w, v, 1);
            }

            /*randomObject =*/
            Instantiate(randomPrefab, randomPos, randomQuat);
            //randomObject.transform.parent = randomObject.transform;

            yield return new WaitForSeconds(1.5f / speedOfEvolution);
        }
    }
}
