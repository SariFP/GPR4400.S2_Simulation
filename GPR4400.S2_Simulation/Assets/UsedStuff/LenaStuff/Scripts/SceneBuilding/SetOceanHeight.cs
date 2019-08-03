using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOceanHeight : MonoBehaviour
{
    public float WaterLevel = 2f;
    private float waterHeight;

    private void Awake()
    {
        transform.position = Vector3.zero;
    }

    private void Start()
    {

    }

    void Update()
    {
        if (SimulationManager.Instance.TerrainGenerated)
        {
            waterHeight = SimulationManager.Instance.Ground + WaterLevel;
            SimulationManager.Instance.WaterLimit = waterHeight;
            transform.Translate(new Vector3(transform.position.x, waterHeight, transform.position.z));
            SimulationManager.Instance.TerrainGenerated = false;
        }
    }
}
