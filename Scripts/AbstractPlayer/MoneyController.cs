using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyController : MonoBehaviour {

    [SerializeField]
    Text label;

    [SerializeField]
    float startMoney;

    public float numMoney { get; private set; }

    void Start()
    {
        numMoney = PlayerPrefs.GetFloat("NumMoney");
        numMoney += startMoney;
        UpdateTextLabel();
    }

    public void UpdateTextLabel()
    {
        label.text = numMoney.ToString();
    }

    public void AddMoney(float value)
    {
        numMoney += value;
        if (numMoney < 0)
        {
            numMoney = 0;
        }
        PlayerPrefs.SetFloat("NumMoney", numMoney);
        UpdateTextLabel();
    }


}
