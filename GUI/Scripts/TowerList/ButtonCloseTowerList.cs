using UnityEngine;

public class ButtonCloseTowerList : MonoBehaviour {

	public void Close()
    {
        gameObject.transform.parent.gameObject.GetComponent<SocketControl>().currentlySocket = null;
        gameObject.transform.parent.gameObject.SetActive(false);
        //call some anim
    }
}
