using UnityEngine;

public class ButtonOptions : MonoBehaviour {

    [SerializeField]
    GameObject panelOptoins;

    public void CallOptionsPanel()
    {
        panelOptoins.SetActive(true);
        gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
    }


}
