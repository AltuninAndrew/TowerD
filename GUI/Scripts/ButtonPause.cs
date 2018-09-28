using UnityEngine;

public class ButtonPause : MonoBehaviour {
    [SerializeField]
    GameObject panelPause;

    [SerializeField]
    GameObject panelOptions;

    public bool isActive { get; private set;}
    

    public void SetPause()
    {
        isActive = !isActive;
        panelPause.SetActive(isActive);
        if(isActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (panelOptions.activeInHierarchy)
        {
            panelOptions.SetActive(false);
        }
    }

}
