using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizeNPCs : MonoBehaviour
{
    public GameObject Player;
    public GameObject Rabbit;
    public GameObject Fireflies;
    public GameObject FogParticle;
    public GameObject[] Waypoint;
    public LayerMask terrainLayer;

    private Terrain terrain;
    private float terrainHeight;
    private RaycastHit hit;


    private void Awake()
    {
        Waypoint = GameObject.FindGameObjectsWithTag("waypoint");
        Player = GameObject.FindGameObjectWithTag("Player");
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
}
