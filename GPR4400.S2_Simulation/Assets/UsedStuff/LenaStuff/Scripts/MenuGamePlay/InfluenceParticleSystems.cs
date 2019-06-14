using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceParticleSystems : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    ParticleSystem.EmissionModule emissionModule;

    void Start()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
        emissionModule = ParticleSystem.emission;
        emissionModule.rateOverTime = SimulationManager.Instance.Emission;
    }
}
