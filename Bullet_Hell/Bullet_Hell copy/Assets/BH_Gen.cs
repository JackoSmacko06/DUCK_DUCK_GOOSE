using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BH_Gen : MonoBehaviour
{
    public int numOfCollums;
    public float speed;
    public Sprite sprite;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    private float angle;
    public Material material;
    public float spinSpeed;
    private float time;

 

    public ParticleSystem system;


    private void Awake()
    {
        Summon();
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, time * spinSpeed);
    }

    void Summon()
    {
        angle = 360f / numOfCollums;

        for (int i = 0; i < numOfCollums; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;

            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 100000;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            var emission = system.emission;
            emission.enabled = false;

            var forma = system.shape;
            forma.enabled = true;

            forma.shapeType = ParticleSystemShapeType.Sprite;
            forma.sprite = null;

            var tex = system.textureSheetAnimation;
            tex.mode = ParticleSystemAnimationMode.Sprites;
            tex.AddSprite(sprite);


            
        }
        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, firerate);


    }

    void DoEmit()
    {
        foreach(Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;
            system.Emit(emitParams, 10);
 
        }
        
        
    }


}
