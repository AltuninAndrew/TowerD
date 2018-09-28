using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    float speed = 10f;
    Vector3 deltaPos;



    void FixedUpdate()
    {
        if (Input.touchCount == 2)
        {
            deltaPos = Input.GetTouch(0).deltaPosition;
            gameObject.transform.Translate(-deltaPos * speed * Time.deltaTime);
        }
        if (Input.GetMouseButton(0))
        {

            gameObject.transform.Translate(-new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * speed * Time.deltaTime);

        }
    }


}
