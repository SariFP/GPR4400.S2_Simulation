using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour {
    ParticleSystem.EmissionModule emission;
    private new ParticleSystem particleSystem;
    private float emissionValue;

    ParticleSystem.ShapeModule shape;
    private float shapeScale;

    void Start() {
        particleSystem = GetComponent<ParticleSystem>();
        emission = particleSystem.emission;
        emissionValue = SimulationManager.Instance.Emission;
        emission.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue);

        shape = particleSystem.shape;
        shapeScale = SimulationManager.Instance.Wideness;
        shape.scale = new Vector3(shapeScale, shapeScale);
    }
       
}
