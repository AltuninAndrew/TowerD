using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsHP : MonoBehaviour {

    Image image;
    public Vector3 defaultScale { get; private set; }
	void Start () {
        image = GetComponent<Image>();
        defaultScale = image.rectTransform.localScale;
	}
	
    public void SetScaleLineHp(float valueHP,float maxNum)
    {
        float x = valueHP / maxNum;
        image.rectTransform.localScale = new Vector3(x, 1, 1);
    }
}
