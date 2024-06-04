using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPlayer : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {

        transform.Translate(-Vector3.forward * Time.deltaTime * speed);
    }
}
