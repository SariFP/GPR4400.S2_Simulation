using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationManager : MonoBehaviour
{
    private static SimulationManager instance;

    public static SimulationManager Instance { get { return instance; } }

    public Slider SliderWideness;
    public Slider SliderDensity;
    public Slider SliderEmission;
    public Slider SliderCelerity;
    public Slider SliderBumpiness;

    public float Wideness = 45f;
    public float Density = 250;
    public float Emission = 5;
    public float Celerity = 2.1f;
    public float Bumpiness = 30f;

    public bool TerrainGenerated;
    public float Ground = 0;
    public float WaterLimit;


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
        SliderWideness.value = Wideness;
        SliderDensity.value = Density;
        SliderEmission.value = /*(int)*/Emission;
        SliderCelerity.value = Celerity;
        SliderBumpiness.value = Bumpiness;
    }

    private void Update()
    {
        Wideness = SliderWideness.value;
        Density = SliderDensity.value;
        Emission =/* (int)*/SliderEmission.value;
        Celerity = SliderCelerity.value;
        Bumpiness = SliderBumpiness.value;
    }
}
