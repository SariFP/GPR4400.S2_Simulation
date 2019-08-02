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

    public LayerMask TerrainLayer;
    private Terrain terrain;
    private float amountOfObjects; /*DENSITY*/
    private float speedOfEvolution; /*CELERITY*/

    private float width;
    private float length;
    private float height;
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
        amountOfObjects = SimulationManager.Instance.Density;

        speedOfEvolution = SimulationManager.Instance.Celerity;

        terrain = GetComponent<Terrain>();
        width = terrain.terrainData.size.x;
        length = terrain.terrainData.size.z;

        StartCoroutine(FindRandomPositions());
    }


    IEnumerator FindRandomPositions()
    {
        do
        {
            randomPosX = Random.Range(transform.position.x - width / 2, width / 2);
            randomPosZ = Random.Range(transform.position.z - length / 2, length / 2);
            if (Physics.Raycast(new Vector3(randomPosX, 100, randomPosZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
            {
                if (hit.point.y > SimulationManager.Instance.WaterLimit)
                {
                    height = hit.point.y;

                    randomPosY = height - deviance;
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

                    Instantiate(randomPrefab, randomPos, randomQuat);
                    amountOfObjects -= 1;

                    yield return new WaitForSeconds(1.5f / speedOfEvolution);
                }
            }
        } while (amountOfObjects > 0);
    }
}
