using UnityEngine;

public class ButtonClosePause : MonoBehaviour {

    public void Close()
    {
        Time.timeScale = 1;

        gameObject.transform.parent.gameObject.SetActive(false);
    }

}
