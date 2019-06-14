using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceParticleSystems : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    ParticleSystem.EmissionModule emissionModule;

    void Start()
    {
        // Get the system and the emission module.
        ParticleSystem = GetComponent<ParticleSystem>();
        emissionModule = ParticleSystem.emission;
        emissionModule.rateOverTime = SimulationManager.Instance.Emission;
        //SetValue();
        Debug.Log("Emission: " + emissionModule.rateOverTime);
    }

    //void SetValue()
    //{
    //    emissionModule.rateOverTime = SimulationManager.Instance.Emission;
    //}
}
