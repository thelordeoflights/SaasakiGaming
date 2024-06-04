using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyoutofBounds : MonoBehaviour
{
    [SerializeField] SpawnLaser spawnLaser;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            spawnLaser.laserCount = 0;
        }
    }
}
