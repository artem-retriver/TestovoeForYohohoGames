using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yohoho
{
    public class CanvasLookAtCamera : MonoBehaviour
    {
        [SerializeField] private Transform _cameraPlayer;

        private void Update()
        {
            transform.LookAt(_cameraPlayer);
        }
    }
}