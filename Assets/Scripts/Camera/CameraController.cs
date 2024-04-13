using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private Transform _playerTransform;
    void Start()
    {
        instance = this;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
