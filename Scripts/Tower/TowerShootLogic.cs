using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TowerController))]
public class TowerShootLogic : MonoBehaviour {
    [SerializeField]
    float shootSpeed = 2f,speedBullet=5f,damagePercnet=20f;

    [SerializeField]
    GameObject textForStats;

    [SerializeField]
    GameObject prefabBullet;

    [SerializeField]
    Transform gunpoint;

    [SerializeField]
    bool shooting = true;

    [SerializeField]
    int maxBullets = 10;

    private bool isActor = false;
    public int currNumBullets { get; private set; }
    private StatsBulletController statsUI;
    private TowerController towerController;
    void Start ()
    {
        towerController = gameObject.GetComponent<TowerController>();
        try
        {
            statsUI = textForStats.GetComponent<StatsBulletController>();
        }
        catch
        {
            Debug.LogError("Set UI element for show statistics");
        }

        RefillBullets();

    }
	
	void Update ()
    {
        if (!isActor)
            StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        isActor = true;
        yield return new WaitForSeconds(shootSpeed);
        if (shooting && (currNumBullets > 0) && towerController.isTracking)
        {
            GameObject bullet = GameObject.Instantiate(prefabBullet, gunpoint.position, Quaternion.identity) as GameObject;
            BulletController bulletController = bullet.GetComponent<BulletController>();
            bulletController.damage = damagePercnet;
            bulletController.distanation = towerController.trackTransform;
            bulletController.speed = speedBullet;
            currNumBullets--;
            statsUI.SetStatistics(currNumBullets);
        }
        isActor = false;
    }

    public void RefillBullets()
    {
        if (currNumBullets<maxBullets)
        {
            currNumBullets = maxBullets;
            textForStats.GetComponent<StatsBulletController>().SetStatistics(currNumBullets);// Don't touch. Don't try use cache this line
        }
        
    }

    public void RefillBullets(int numBulletsAdd)
    {
        maxBullets = numBulletsAdd;
        currNumBullets = maxBullets;
        textForStats.GetComponent<StatsBulletController>().SetStatistics(currNumBullets); // Don't touch. Don't try use cache this line
    }

    public void SetShootSpeed(float value)
    {
        shootSpeed = value;
    }

    public float GetShootSpeed()
    {
        return shootSpeed;
    }

    public void SetSpeedBullets(float value)
    {
        speedBullet = value;
    }

    public void SetDamagePercnet(float value)
    {
        damagePercnet = value;
    }

}
