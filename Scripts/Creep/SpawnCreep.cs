using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCreep : MonoBehaviour {

    [SerializeField]
    GameObject creepPrefab;
    [SerializeField]
    List<Transform> creepWayPoints = new List<Transform>();
    [SerializeField]
    int maxNumCreepInWave = 0;
    [SerializeField]
    bool pauseSpawn;
    [SerializeField]
    float spawnTimeInterval = 0, startDelay = 0, waveTimeInterval = 0;

    [SerializeField]
    int numWaves;

    private bool spawnEnd = false;
    private Vector3 spawnPos;

    public int countSpawn { get; private set; }
    public int countWave { get; private set; }
    
    void Start ()
    {
        countSpawn = 0;
        countWave = 0;
        spawnPos = gameObject.transform.position;
        InvokeRepeating("Spawn", startDelay, spawnTimeInterval);
        InvokeRepeating("SpawnWave", waveTimeInterval, waveTimeInterval);
	}

    private void SpawnWave()
    {
        if (spawnEnd&&(countWave<numWaves-1))
        {
            countSpawn = 0;
            spawnEnd = false;
            countWave++;
        }
    }

    private void Spawn()
    {  
        if (!pauseSpawn)
        {
            if (countSpawn < maxNumCreepInWave)
            {
                GameObject creep = GameObject.Instantiate(creepPrefab, spawnPos, Quaternion.identity) as GameObject;
                creep.name = "Creep " + (countSpawn+1);
                creep.GetComponent<MoveCreep>().SetTargetPoints(creepWayPoints);
                countSpawn++;
            } else
            {
                spawnEnd = true;
            }
        } 
    }

    public float GetSpawnTimeInterval()
    {
        return spawnTimeInterval;
    }

    public float GetStartDelay()
    {
        return startDelay;
    }

    public void SetSpawnTimeInterval(float value)
    {
        spawnTimeInterval = value;
    }
    
    public void SetStartDelay(float value)
    {
        startDelay = value;
    }

    public bool GetStateSpawn()
    {
        return pauseSpawn;
    }

    public void EnablePaue(bool flag)
    {
        pauseSpawn = flag;
    }

    public void ResetNumWave()
    {
        countWave = 0;
    }
}
