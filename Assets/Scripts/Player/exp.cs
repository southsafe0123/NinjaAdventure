using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : MonoBehaviour
{
    public ParticleSystem psCollide;
    private void Start()
    {
        psCollide = GetComponent<ParticleSystem>();
        psCollide.trigger.SetCollider(0, GameObject.Find("player").GetComponent<BoxCollider2D>());
    }
    private void OnParticleTrigger()
    {

        List<ParticleSystem.Particle> particleEnter = new List<ParticleSystem.Particle>();

        ParticleSystem ps = GetComponent<ParticleSystem>();
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particleEnter);
         
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = particleEnter[i];
            p.remainingLifetime = 0;

            PlayerStatus.expUpdate(); // tăng exp

            particleEnter[i] = p;
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particleEnter);
    }
}
