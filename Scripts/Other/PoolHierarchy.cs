using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHierarchy : MonoBehaviour {

    private List<GameObject> elementsPool = new List<GameObject>();

    //integrate the parent object! 

    public GameObject InstantiateObj(GameObject prefab, Vector3 positionSpawn, Quaternion rotation)
    {
        GameObject returnedObj=null;

        foreach(GameObject obj in elementsPool)
        {
            if (obj.activeInHierarchy == false)
            {
                returnedObj = obj.gameObject;
                returnedObj.transform.SetPositionAndRotation(positionSpawn, rotation);
                returnedObj.SetActive(true);
                break;   
            }
        }

        if(returnedObj==null)
        {
            returnedObj = GameObject.Instantiate(prefab, positionSpawn, rotation);
            elementsPool.Add(returnedObj);
           
        }

        return returnedObj;

    }

    public void RemoveAllElements()
    {
       for(int i=0;i<elementsPool.Count;i++)
       {
            Destroy(elementsPool[i]);
       }
       elementsPool.Clear();
    }

   

    

}   
