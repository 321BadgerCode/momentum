using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public bool Default;
    public float bloom;
    public float distortion;
    public float vignette;
    public float exposure;

    private Bloom bloomLayer;
    private LensDistortion Lens;
    private Vignette Vignette;
    private AutoExposure Exposure;

    void Start()
    {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();

        //Bloom
        bloomLayer = null;
        volume.profile.TryGetSettings(out bloomLayer);
        bloomLayer.enabled.value = true;

        //LensDistortion
        Lens = null;
        volume.profile.TryGetSettings(out Lens);
        Lens.enabled.value = true;

        //Vignette
        Vignette = null;
        volume.profile.TryGetSettings(out Vignette);
        Vignette.enabled.value = true;

        //Exposure
        Exposure = null;
        volume.profile.TryGetSettings(out Exposure);
        Exposure.enabled.value = true;
    }


    void Update()
    {
        //Default
        if (Default == true)
        {
            bloom = 10f;
            distortion = 0f;
            vignette = .2f;
            exposure = 1f;
        }
        else
        {
            bloomLayer.intensity.value = bloom;
            Lens.intensity.value = distortion;
            Vignette.intensity.value = vignette;
            Exposure.keyValue.value = exposure;
        }
        //Bloom Max
        if (bloom > 20)
        {
            bloom = 10f;
        }
        //Exposure Max
        if (distortion > 50)
        {
            distortion = 0f;
        }
        //Exposure Max
        if (vignette > 1)
        {
            vignette = .2f;
        }
        //Exposure Max
        if (exposure > 2)
        {
            exposure = 1f;
        }
    }
}
