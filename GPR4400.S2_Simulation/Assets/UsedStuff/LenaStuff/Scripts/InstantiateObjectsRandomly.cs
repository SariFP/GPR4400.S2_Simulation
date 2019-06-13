using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectsRandomly : MonoBehaviour
{
    public float AmountOfObjects = 100;
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

    private float TerrainXMin;
    private float TerrainXMax;
    private float TerrainZMin;
    private float TerrainZMax;
    private float TerrainWidth;
    private float TerrainLength;
    private float TerrainHeight;

    private RaycastHit hit;
    //private GameObject randomObject;
    private GameObject randomPrefab;
    private Quaternion randomQuat;
    private Vector3 randomPos;
    private float randomPosX;
    private float randomPosZ;
    private float randomPosY;
    private float terrainHeight;


    void Start()
    {
        TerrainXMin = Terrain.transform.position.x+15;
        TerrainZMin = Terrain.transform.position.z+15;
        TerrainWidth = Terrain.terrainData.size.x-30;
        TerrainLength = Terrain.terrainData.size.z-30;
        TerrainHeight = Terrain.terrainData.size.y;
        TerrainXMax = TerrainXMin + TerrainWidth;
        TerrainZMax = TerrainZMin + TerrainLength;

        StartCoroutine(FindRandomPositions());
    }


    IEnumerator FindRandomPositions()
    {
        for (int i = 0; i < AmountOfObjects; i++)
        {
            randomPosX = Random.Range(TerrainXMin, TerrainXMax);
            randomPosZ = Random.Range(TerrainZMin, TerrainZMax);
            if (Physics.Raycast(new Vector3(randomPosX, 100, randomPosZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
            {
                terrainHeight = hit.point.y;
            }
            randomPosY = terrainHeight-0.05f;
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

            /*randomObject =*/ Instantiate(randomPrefab, randomPos, randomQuat);
            //randomObject.transform.parent = randomObject.transform;

            yield return new WaitForSeconds(1);
        }
    }
}
