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

    public float Wideness = 63.5f;
    public float Density = 250;
    public float Emission = 5f;
    public float Celerity = 2.1f;
    public float Bumpiness = 5f;


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
        Wideness = 63.5f;
        Density = 250f;
        Emission = 5f;
        Celerity = 2.1f;
        Bumpiness = 5f;

        SliderWideness.value = Wideness;
        SliderDensity.value = Density;
        SliderEmission.value = Emission;
        SliderCelerity.value = Celerity;
        SliderBumpiness.value = Bumpiness;
    }

    private void Update()
    {
        Wideness = SliderWideness.value;
        Density = SliderDensity.value;
        Emission = SliderEmission.value;
        Celerity = SliderCelerity.value;
        Bumpiness = SliderBumpiness.value;
    }


}
