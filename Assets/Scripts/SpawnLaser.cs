using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    public GameObject[] lasersPrefabs;
    public int laserCount = 1;
    public int waveCount = 1;
    void Start()
    {
        SpawnLaserWave(waveCount);
    }

    void Update()
    {
        //laserCount = FindObjectsOfType<MoveTowardPlayer>().Length;
        if (laserCount == 0)
        {
            waveCount++;
            SpawnLaserWave(waveCount);
        }
    }
    void SpawnLaserWave(int laserToSpawn)
    {
        int laserIndex = Random.Range(0, lasersPrefabs.Length);
        for (int i = 0; i < laserToSpawn; i++)
        {
            Instantiate(lasersPrefabs[laserIndex], new Vector3(0, 0, 10), lasersPrefabs[laserIndex].transform.rotation);
        }

    }
}
