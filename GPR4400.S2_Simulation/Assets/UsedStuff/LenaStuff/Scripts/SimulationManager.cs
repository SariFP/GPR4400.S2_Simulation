using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    private static SimulationManager instance;

    public static SimulationManager Instance { get { return instance; } }

    public GameObject SliderWideness;
    public GameObject SliderDensity;
    public GameObject SliderEmission;
    public GameObject SliderCelerity;
    public GameObject SliderBumpiness;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (true)
        {

        }
    }
}
