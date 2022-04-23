using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pena : MonoBehaviour
{
    private List<ParticleSystem.Particle> triggerParticles;
    private ParticleSystem waterParticleSystem;

    private void Start()
    {
        waterParticleSystem = GetComponent<ParticleSystem>();
        triggerParticles = new List<ParticleSystem.Particle>(waterParticleSystem.main.maxParticles);

    }
    private void OnParticleTrigger()
    {
        int count = waterParticleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, triggerParticles);
        Debug.Log(count);
    }
}
