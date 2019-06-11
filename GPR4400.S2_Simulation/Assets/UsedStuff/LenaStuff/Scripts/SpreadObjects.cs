using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadObjects : MonoBehaviour
{
    public GameObject TreePrefab;
    public GameObject PlenteousTreePrefeab;
    public GameObject BushPrefab;
    public GameObject PinkSingleXtalPrefab;
    public GameObject GreenSingleXtalPrefab;
    public GameObject BlueSingleXtalPrefab;
    public GameObject PinkGroupXtalPrefab;
    public GameObject YellowGroupXtalPrefab;


    //public Terrain Terrain;
    private int terrainSize = 50;
    private Vector3 position;
    private int[,] terrain;
    private int u;
    private int w;
    private int v;
    System.Random rand = new System.Random();


    void Start()
    {
        terrain = new int[50, 50];
        //Terrain = GetComponent<Terrain>();
        //terrainSize = Terrain.terrainData.size;
        SpreadObjs();
    }



    private void SpreadObjs()
    {
        for (int x = 0; x < terrainSize; x++)
        {
            for (int y = 0; y < terrainSize; y++)
            {
                terrain[x, y] = rand.Next(50);
            }
        }

        StartCoroutine(InstantiateObjs());
        StartCoroutine(InstantiateObjsInvert());
    }

    IEnumerator InstantiateObjs()
    {
        for (int x = 0; x < terrainSize / 2; x++)
        {
            for (int y = 0; y < terrainSize / 2; y++)
            {
                u = Random.Range(-30, 30);
                w = Random.Range(0, 360);
                v = Random.Range(-30, 30);
                Quaternion quatDir = new Quaternion(0, w, 0, 1);
                Quaternion quatGrade = new Quaternion(u, w, v, 1);

                if (terrain[x, y] == 4)
                {
                    Instantiate(TreePrefab, new Vector3(x, 0, y), quatDir);
                }
                if (terrain[x, y] == 13)
                {
                    Instantiate(TreePrefab, new Vector3(-x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 28)
                {
                    Instantiate(TreePrefab, new Vector3(-x, 0, y), quatDir);
                }
                if (terrain[x, y] == 42)
                {
                    Instantiate(TreePrefab, new Vector3(x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 6)
                {
                    Instantiate(BlueSingleXtalPrefab, new Vector3(x, -0.1f, y), quatDir);
                }
                if (terrain[x, y] == 18)
                {
                    Instantiate(BlueSingleXtalPrefab, new Vector3(-x, -0.1f, -y), quatDir);
                }
                if (terrain[x, y] == 26)
                {
                    Instantiate(BlueSingleXtalPrefab, new Vector3(-x, -0.1f, y), quatDir);
                }
                if (terrain[x, y] == 33)
                {
                    Instantiate(BlueSingleXtalPrefab, new Vector3(x, -0.1f, -y), quatDir);
                }
                if (terrain[x, y] == 9)
                {
                    Instantiate(PlenteousTreePrefeab, new Vector3(x, 0, y), quatDir);
                }
                if (terrain[x, y] == 11)
                {
                    Instantiate(PlenteousTreePrefeab, new Vector3(-x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 27)
                {
                    Instantiate(PlenteousTreePrefeab, new Vector3(-x, 0, y), quatDir);
                }
                if (terrain[x, y] == 49)
                {
                    Instantiate(PlenteousTreePrefeab, new Vector3(x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 2)
                {
                    Instantiate(PinkSingleXtalPrefab, new Vector3(x, -0.1f, y), quatGrade);
                }
                if (terrain[x, y] == 23)
                {
                    Instantiate(PinkSingleXtalPrefab, new Vector3(-x, -0.1f, -y), quatGrade);
                }
                if (terrain[x, y] == 31)
                {
                    Instantiate(PinkSingleXtalPrefab, new Vector3(-x, -0.1f, y), quatGrade);
                }
                if (terrain[x, y] == 44)
                {
                    Instantiate(PinkSingleXtalPrefab, new Vector3(x, -0.1f, -y), quatGrade);
                }
                if (terrain[x, y] == 1)
                {
                    Instantiate(BushPrefab, new Vector3(x, 0, y), quatDir);
                }
                if (terrain[x, y] == 17)
                {
                    Instantiate(BushPrefab, new Vector3(-x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 25)
                {
                    Instantiate(BushPrefab, new Vector3(-x, 0, y), quatDir);
                }
                if (terrain[x, y] == 35)
                {
                    Instantiate(BushPrefab, new Vector3(x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 12)
                {
                    Instantiate(YellowGroupXtalPrefab, new Vector3(x, -0.1f, y), quatGrade);
                }
                if (terrain[x, y] == 29)
                {
                    Instantiate(YellowGroupXtalPrefab, new Vector3(-x, -0.1f, -y), quatGrade);
                }
                if (terrain[x, y] == 34)
                {
                    Instantiate(YellowGroupXtalPrefab, new Vector3(-x, -0.1f, y), quatGrade);
                }
                if (terrain[x, y] == 47)
                {
                    Instantiate(YellowGroupXtalPrefab, new Vector3(x, -0.1f, -y), quatGrade);
                }
                if (terrain[x, y] == 5)
                {
                    Instantiate(PinkGroupXtalPrefab, new Vector3(x, -0.1f, y), quatDir);
                }
                if (terrain[x, y] == 15)
                {
                    Instantiate(PinkGroupXtalPrefab, new Vector3(-x, -0.1f, -y), quatDir);
                }
                if (terrain[x, y] == 21)
                {
                    Instantiate(PinkGroupXtalPrefab, new Vector3(-x, -0.1f, y), quatDir);
                }
                if (terrain[x, y] == 41)
                {
                    Instantiate(PinkGroupXtalPrefab, new Vector3(x, -0.1f, -y), quatDir);
                }

                yield return new WaitForSeconds(.1f);
            }
        }
    }

    IEnumerator InstantiateObjsInvert()
    {
        for (int x = terrainSize; x > terrainSize / 2; x--)
        {
            for (int y = terrainSize; y > terrainSize / 2; y--)
            {
                u = rand.Next(-30, 30);
                w = rand.Next(0, 360);
                v = rand.Next(-30, 30);

                Quaternion quatDir = new Quaternion(0, w, 0, 1);
                Quaternion quatGrade = new Quaternion(u, w, v, 1);

                if (terrain[x, y] == 4)
                {
                    Instantiate(TreePrefab, new Vector3(x, 0, y), quatDir);
                }
                if (terrain[x, y] == 13)
                {
                    Instantiate(TreePrefab, new Vector3(-x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 28)
                {
                    Instantiate(TreePrefab, new Vector3(-x, 0, y), quatDir);
                }
                if (terrain[x, y] == 42)
                {
                    Instantiate(TreePrefab, new Vector3(x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 6)
                {
                    Instantiate(BlueSingleXtalPrefab, new Vector3(x, -0.1f, y), quatDir);
                }
                if (terrain[x, y] == 18)
                {
                    Instantiate(BlueSingleXtalPrefab, new Vector3(-x, -0.1f, -y), quatDir);
                }
                if (terrain[x, y] == 26)
                {
                    Instantiate(BlueSingleXtalPrefab, new Vector3(-x, -0.1f, y), quatDir);
                }
                if (terrain[x, y] == 33)
                {
                    Instantiate(BlueSingleXtalPrefab, new Vector3(x, -0.1f, -y), quatDir);
                }
                if (terrain[x, y] == 9)
                {
                    Instantiate(PlenteousTreePrefeab, new Vector3(x, 0, y), quatDir);
                }
                if (terrain[x, y] == 11)
                {
                    Instantiate(PlenteousTreePrefeab, new Vector3(-x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 27)
                {
                    Instantiate(PlenteousTreePrefeab, new Vector3(-x, 0, y), quatDir);
                }
                if (terrain[x, y] == 49)
                {
                    Instantiate(PlenteousTreePrefeab, new Vector3(x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 2)
                {
                    Instantiate(PinkSingleXtalPrefab, new Vector3(x, -0.1f, y), quatGrade);
                }
                if (terrain[x, y] == 23)
                {
                    Instantiate(PinkSingleXtalPrefab, new Vector3(-x, -0.1f, -y), quatGrade);
                }
                if (terrain[x, y] == 31)
                {
                    Instantiate(PinkSingleXtalPrefab, new Vector3(-x, -0.1f, y), quatGrade);
                }
                if (terrain[x, y] == 44)
                {
                    Instantiate(PinkSingleXtalPrefab, new Vector3(x, -0.1f, -y), quatGrade);
                }
                if (terrain[x, y] == 1)
                {
                    Instantiate(BushPrefab, new Vector3(x, 0, y), quatDir);
                }
                if (terrain[x, y] == 17)
                {
                    Instantiate(BushPrefab, new Vector3(-x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 25)
                {
                    Instantiate(BushPrefab, new Vector3(-x, 0, y), quatDir);
                }
                if (terrain[x, y] == 35)
                {
                    Instantiate(BushPrefab, new Vector3(x, 0, -y), quatDir);
                }
                if (terrain[x, y] == 12)
                {
                    Instantiate(YellowGroupXtalPrefab, new Vector3(x, -0.1f, y), quatGrade);
                }
                if (terrain[x, y] == 29)
                {
                    Instantiate(YellowGroupXtalPrefab, new Vector3(-x, -0.1f, -y), quatGrade);
                }
                if (terrain[x, y] == 34)
                {
                    Instantiate(YellowGroupXtalPrefab, new Vector3(-x, -0.1f, y), quatGrade);
                }
                if (terrain[x, y] == 47)
                {
                    Instantiate(YellowGroupXtalPrefab, new Vector3(x, -0.1f, -y), quatGrade);
                }
                if (terrain[x, y] == 5)
                {
                    Instantiate(PinkGroupXtalPrefab, new Vector3(x, -0.1f, y), quatDir);
                }
                if (terrain[x, y] == 15)
                {
                    Instantiate(PinkGroupXtalPrefab, new Vector3(-x, -0.1f, -y), quatDir);
                }
                if (terrain[x, y] == 21)
                {
                    Instantiate(PinkGroupXtalPrefab, new Vector3(-x, -0.1f, y), quatDir);
                }
                if (terrain[x, y] == 41)
                {
                    Instantiate(PinkGroupXtalPrefab, new Vector3(x, -0.1f, -y), quatDir);
                }

                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
