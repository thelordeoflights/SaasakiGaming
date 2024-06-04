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
        transform.position = _player.transform.position + new Vector3(-0.072f, 5.43f, -5.12f);
    }
}
