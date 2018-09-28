using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatRotation : MonoBehaviour {


    [SerializeField]
    float defaultValueRotX = 54;
	void Update () {
        transform.rotation = Quaternion.Euler(defaultValueRotX, 0, 0);
	}
}
