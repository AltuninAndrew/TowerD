using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWingsController : MonoBehaviour {

    public float speedRotation=10f;
	void Update () {
        transform.Rotate(0, 0, speedRotation * Time.deltaTime);
	}
}
