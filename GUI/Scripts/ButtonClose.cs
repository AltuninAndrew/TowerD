using UnityEngine;

public class ButtonClose : MonoBehaviour {

	public void Close()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
