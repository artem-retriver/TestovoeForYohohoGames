using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Yohoho
{
    public class CameraPoolController : MonoBehaviour
    {
        private CinemachineVirtualCamera[] _virtualCameras;

        private void Start()
        {
            _virtualCameras = GetComponentsInChildren<CinemachineVirtualCamera>();
        }

        public void StartMoveCameras()
        {
            _virtualCameras[0].enabled = false;
            _virtualCameras[1].enabled = true;
        }
    }
}