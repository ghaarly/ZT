using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splinterAnimation : MonoBehaviour
{
    public bool isPlaying;
    ParticleSystem[] Plank;

    void Start()
    {
        Plank = GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (isPlaying == true)
        {
            Plank[0].Play();
            Plank[1].Play();
         
            isPlaying = false;
        }
    }
}
