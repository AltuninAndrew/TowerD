using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOptionExitOnMenu : MonoBehaviour {

	public void ExitOnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
