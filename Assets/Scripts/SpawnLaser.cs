using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SpawnLaser : MonoBehaviour
{
    [SerializeField] GameObject WinScreen;
    [SerializeField] PlayerState playerState;
    [SerializeField] int TotalWaves = 5;
    [SerializeField] TextMeshProUGUI _waveCount;
    public GameObject[] lasersPrefabs;

    public int laserCount = 1;
    public int waveCount = 1;

    void Start()
    {
        WinScreen.SetActive(false);
        SpawnLaserWave(waveCount);
    }

    void Update()
    {
        laserCount = FindObjectsOfType<MoveTowardPlayer>().Length;
        //Debug.Log("LaserCount: " + laserCount + " WaveCount: " + waveCount + " TotalWaver: " + TotalWaves);

        if (laserCount == 0 && !playerState.isDead)
        {
            if (waveCount >= TotalWaves)
            {

                WinScreen.SetActive(true);
            }
            else
            {
                waveCount++;
                SpawnLaserWave(waveCount);
            }
        }
        _waveCount.text = "Wave:" + waveCount;

    }
    void SpawnLaserWave(int laserToSpawn)
    {
        for (int i = 0; i < laserToSpawn; i++)
        {
            int laserIndex = Random.Range(0, lasersPrefabs.Length);
            var LaserGO = Instantiate(lasersPrefabs[laserIndex], new Vector3(6.92f, 1.5f, 17 + i * 5), lasersPrefabs[laserIndex].transform.rotation);
            LaserGO.GetComponent<MoveTowardPlayer>().speed = laserToSpawn * 2f;
        }

    }
}
