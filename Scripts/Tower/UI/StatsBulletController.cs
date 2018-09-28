using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsBulletController : MonoBehaviour {

    public void SetStatistics(int value)
    {
        GetComponent<Text>().text = value.ToString();
    }
	

}
