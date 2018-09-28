using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSaleTow : MonoBehaviour {
    [SerializeField]
    RefOnTower refOnTower;
    [SerializeField]
    MoneyController moneyController;

    const int COEFFICIENT = 2;

    public void Sell()
    {
        GameObject curTower = refOnTower.currentTowerObj;
        float salePrice = curTower.GetComponent<AddiData>().currTowerPrice / COEFFICIENT;
        moneyController.AddMoney(salePrice);
        curTower.GetComponentInParent<TowerPlace>().CleanSocket();
        Destroy(curTower);
    }

}
