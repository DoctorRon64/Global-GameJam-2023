using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class IncreasingVinette : MonoBehaviour
{
    private Transform player;
    public PostProcessVolume volume;
    public GameObject target;
    public float Smoothness;

    void Awake()
    {
        player = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        IfLower();
    }

    void IfLower()
    {  
        var volume = target.GetComponent<PostProcessVolume>();
        if (volume.profile.TryGetSettings<Vignette>(out var Vignette))
        {
            Vignette.intensity.value = Smoothness * Time.time;
        }
    }
}
