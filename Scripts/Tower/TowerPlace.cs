using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour,IPointerDownHandler{

    [SerializeField]
    SocketControl panelTowerList; //change to new variant obj find
    [SerializeField]
    RefOnTower panelTowerMenu; //change to new variant obj find
    [SerializeField]
    ButtonPause buttonPause; //change to new variant obj find
    private GameObject currentTower;
    private bool isEmpty = true;


    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (isEmpty && (panelTowerList.currentlySocket == null) 
            && !panelTowerList.gameObject.activeSelf && !panelTowerMenu.gameObject.activeInHierarchy && !buttonPause.isActive)
        {
            panelTowerList.gameObject.SetActive(true);
            panelTowerList.GetComponent<SocketControl>().currentlySocket = gameObject;
            
            //*call anim
        }
        else
        {    
            if(!isEmpty && !buttonPause.isActive)
            {
                panelTowerMenu.gameObject.SetActive(true);
                panelTowerMenu.currentTowerObj = currentTower;
            }
            //*call anim
        }
    }


    /// <summary>
    /// To install a new tower in the current socket
    /// </summary>
    /// <param name="prefab">Prefab orig tower</param>
    /// <param name="speedRotation">Parameter speed of rotation of the tower</param>
    /// <param name="damage">Tower damage parameter</param>
    /// <param name="speedBullets">Parameter speed of fly bullets</param>
    /// <param name="shootSpeed">Shood speed tower parameter</param>
    /// <param name="numBullets">Starting number of bullets</param>
    /// <param name="price">Tower price</param>
    public void InstantiateTower(GameObject prefab, int speedRotation, float damage, float speedBullets, float shootSpeed, int numBullets,float price)
    {
        if (isEmpty&&panelTowerList.currentlySocket == gameObject)
        {
            GameObject newTower = GameObject.Instantiate(prefab, transform.position, transform.rotation);
            newTower.transform.SetParent(gameObject.transform);
            newTower.GetComponent<TowerController>().SetSpeedRotate(speedRotation);
            newTower.GetComponent<TowerShootLogic>().SetDamagePercnet(damage);
            newTower.GetComponent<TowerShootLogic>().SetShootSpeed(shootSpeed);
            newTower.GetComponent<TowerShootLogic>().SetSpeedBullets(speedBullets);
            newTower.GetComponent<TowerShootLogic>().RefillBullets(numBullets);
            newTower.GetComponent<AddiData>().currTowerPrice = price;
            panelTowerList.gameObject.SetActive(false);
            //*call anim
            isEmpty = false;
            currentTower = newTower;
            panelTowerList.currentlySocket = null;
        }
    }


    /// <summary>
    /// Clear the reference to the old tower
    /// </summary>
    public void CleanSocket()
    {
        isEmpty = true;
        currentTower = null;
        panelTowerList.currentlySocket = null;
        panelTowerMenu.gameObject.SetActive(false);
    }

    
   
}
