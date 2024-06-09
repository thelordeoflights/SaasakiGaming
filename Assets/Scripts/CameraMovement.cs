using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject _player;
    void Start()
    {
    }

    void LateUpdate()
    {
        transform.position = _player.transform.position + new Vector3(0.33f, 7.91f, -9f);
    }
}
