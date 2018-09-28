using UnityEngine;
using UnityEngine.UI;

public class UIOptionShadow : MonoBehaviour {


    private Toggle toggle;
    void Start()
    {
        toggle = GetComponent<Toggle>();

        if (PlayerPrefs.GetInt("ShadowPrefs") == 0)
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
        if(toggle.isOn)
        {
            PlayerPrefs.SetInt("ShadowPrefs", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ShadowPrefs", 0);
        }

    }
}
