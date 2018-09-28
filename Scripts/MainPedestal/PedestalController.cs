using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalController : MonoBehaviour {

    [SerializeField]
    private float maxHP = 200;

    [SerializeField]
    StatsHP statsHp;

    [SerializeField]
    GameObject textLabel;

    [SerializeField]
    private float numRemoveHPperOneCreep = 67;

    public float hp { get; private set; }

    void Start()
    {
        hp = maxHP;
    }

	void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            AddHP(-numRemoveHPperOneCreep);
            CheckHP();
        }
    }

    void CheckHP()
    {
        if(hp<=0)
        {
            textLabel.SetActive(true); // add anim
            Time.timeScale = 0;
        }
    }

    void AddHP(float value)
    {
        hp += value;
        if(hp<0)
        {
            hp = 0;
        }
        statsHp.SetScaleLineHp(hp, maxHP);
    }
}
