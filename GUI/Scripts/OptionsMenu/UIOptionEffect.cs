using UnityEngine;
using UnityEngine.UI;

public class UIOptionEffect : MonoBehaviour {


    private Toggle toggle;
    void Start()
    {
        toggle = GetComponent<Toggle>();

        if (PlayerPrefs.GetInt("EffectsPrefs") == 0)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
    }

    public virtual void ToggleActive()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("EffectsPrefs", 1);
        }
        else
        {
            PlayerPrefs.SetInt("EffectsPrefs", 0);
        }

    }
}
