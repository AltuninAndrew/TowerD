using UnityEngine;

public class ButtonTowerControl : MonoBehaviour {

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int speedRotation=5, numBullets=0;

    [SerializeField]
    float damage=0, speedBullets=8, shootSpeed=0,price = 0;
    
    private GameObject socket;
    private TowerPlace place;
    private MoneyController playerMoneyController;
    public void Instantiate()
    {
        playerMoneyController = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyController>();
        if (playerMoneyController.numMoney >= price)
        {
            socket = gameObject.transform.parent.transform.parent.GetComponentInParent<SocketControl>().currentlySocket; // call 
            place = socket.GetComponent<TowerPlace>();
            place.InstantiateTower(prefab, speedRotation, damage, speedBullets, shootSpeed, numBullets, price);
            playerMoneyController.AddMoney(-price);
        }
        else
        {
            Debug.Log("no money");
        }
    }
}
