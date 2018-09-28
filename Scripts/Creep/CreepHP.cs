using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepHP : MonoBehaviour {

    [SerializeField]
    float maxHP = 100;

    [SerializeField]
    GameObject lineStatsHP;

    [SerializeField]
    float moneyForDestruct=10;

    public float hp { get; private set;}
    private StatsHP uiStatsElement;
    private MoneyController moneyController;
    void Start()
    {
        moneyController = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyController>();
        hp = maxHP;
        try
        {
            uiStatsElement = lineStatsHP.GetComponent<StatsHP>();
        }
        catch
        {
            Debug.LogError("Set UI element for show statistics");
        }
        
    }

	void Update () {
        if (hp <= 0)
        {
            moneyController.AddMoney(moneyForDestruct);
            Destroy(gameObject);
        }
            
    }

    public void SetHP(float value)
    {
        if ((value>=0)&&(value<=maxHP))
        {
            hp = value;
            uiStatsElement.SetScaleLineHp(hp,maxHP);
        }       
    }

    public void AddHp(float value)
    {
        if ((hp + value) <= maxHP)
        {
            hp += value;
            uiStatsElement.SetScaleLineHp(hp,maxHP);
        }
    }

    public float ReturnMaxHp()
    {
        return maxHP;
    }

    public void SetDefaultHP()
    {
        hp = maxHP;
        uiStatsElement.SetScaleLineHp(hp,maxHP);
    }

    
   
}
