using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour {

    public void CallMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
