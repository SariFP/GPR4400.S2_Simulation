using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour {
    ParticleSystem.EmissionModule emission;
    private new ParticleSystem particleSystem;
    private float emissionValue;

    void Start() {
        particleSystem = GetComponent<ParticleSystem>();
        emission = particleSystem.emission;
        emissionValue = SimulationManager.Instance.Emission;
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue);
    }
       
}
