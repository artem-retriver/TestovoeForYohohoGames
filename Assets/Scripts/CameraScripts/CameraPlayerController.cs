using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yohoho
{
    public class CameraPlayerController : MonoBehaviour
    {
        [SerializeField] private Transform player;

        private Vector3 offset;

        void Start()
        {
            offset = transform.position - player.position;
        }

        void FixedUpdate()
        {
            Vector3 _newPosition = new(offset.x + player.position.x, transform.position.y, offset.z + player.position.z);
            transform.position = _newPosition;
        }

    }
}

