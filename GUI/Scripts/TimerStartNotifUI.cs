using UnityEngine;
using UnityEngine.UI;

public class TimerStartNotifUI : MonoBehaviour {

    [SerializeField]
    private int startDelay = 20;


    private Text textLabel;

    private int counter;
    private bool isActive = true;

    void Start()
    {
        try
        {
            textLabel = GetComponent<Text>();
        }
        catch
        {
            Debug.LogError("Please,set text component");
        }

        InvokeRepeating("UpdateTextLabel", 0, 1);

    }


    void UpdateTextLabel()
    {
        if(isActive&&(counter<startDelay))
        {
            counter++;
            textLabel.text = "The game will start in " + (startDelay - counter) + " seconds, prepare your town";
        }
        else
        {
            counter = 0;
            isActive = false;
            gameObject.SetActive(false);
        }

    }
}

