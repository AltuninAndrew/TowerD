using UnityEngine;

public class ButtonRefillTow : MonoBehaviour {

    [SerializeField]
    int priceRefill = 10;

    [SerializeField]
    private RefOnTower refOnTower;

    [SerializeField]
    MoneyController moneyController;

    public void Refill()
    {
        TowerShootLogic towerShootLogic = refOnTower.currentTowerObj.GetComponent<TowerShootLogic>();
        int dataNumBull = towerShootLogic.currNumBullets;

        if(moneyController.numMoney>=priceRefill)
        {
            towerShootLogic.RefillBullets();
        }

        if (towerShootLogic.currNumBullets>dataNumBull)
        {
            moneyController.AddMoney(-priceRefill);
        }
        

    }
}
