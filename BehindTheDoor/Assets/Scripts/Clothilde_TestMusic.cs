using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothilde_TestMusic : MonoBehaviour
{
    public StudioEventEmitter music;
    [FMODUnity.ParamRef]
    public string musicParameter;
    [Range(0, 2)]
    public int musicIntensity;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (music.IsPlaying())
        {
            RuntimeManager.StudioSystem.setParameterByName(musicParameter, musicIntensity);
        }
    }
}
