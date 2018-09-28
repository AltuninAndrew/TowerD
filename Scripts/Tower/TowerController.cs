using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    [SerializeField]
    float speedRotate = 5f;

    public Transform trackTransform { get; private set; }
    GameObject enemy;
    private Quaternion defaultRotation;
    private Quaternion lookRotation;
    private float velocityRotate;
    public bool isTracking { get; private set; }
    void Start()
    {
        defaultRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        Tracking();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy"&&!isTracking)
        {
            enemy = col.gameObject;
            isTracking = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
       
        if(col.gameObject == enemy)
        {
            isTracking = false;
            //ResetEnemy();
            enemy = null;
            isTracking = false;
        }
    }

    void Tracking()
    {
        if (enemy == null)
            isTracking = false;

        if (isTracking)
        {
            trackTransform = enemy.transform;
            lookRotation = Quaternion.LookRotation(trackTransform.position - transform.position);
            velocityRotate = Mathf.Lerp(0, 1, Time.deltaTime) * speedRotate;
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, velocityRotate);
        } else
        {
             transform.rotation = Quaternion.Lerp(transform.rotation, defaultRotation, velocityRotate);
        }  
    }


    public void SetSpeedRotate(int value)
    {
        speedRotate = value;
    }

    public float GetSpeedRotate()
    {
        return speedRotate;
    }

    public void ResetEnemy()
    {
        enemy = null;
        isTracking = false;
        trackTransform = null;
    }
}


