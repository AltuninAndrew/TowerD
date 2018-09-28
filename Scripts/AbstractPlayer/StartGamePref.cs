using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGamePref : MonoBehaviour {

    [SerializeField]
    Light mainLight;

    [SerializeField]
    ParticleSystem particleGas;

    void Start()
    {
        SetPrefs();

    }

    public void SetPrefs()
    {
        if (PlayerPrefs.GetInt("ShadowPrefs") == 0)
        {
            mainLight.shadows = LightShadows.None;
            //add variants shadow;
        }
        else
        {
            mainLight.shadows = LightShadows.Soft;
            //add variants shadow;  
        }

        if (PlayerPrefs.GetInt("EffectsPrefs") == 0)
        {
            particleGas.Stop();
            particleGas.gameObject.SetActive(false);
        }
        else
        {
            particleGas.gameObject.SetActive(true);
            particleGas.Play();
        }


    }


}
