using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yohoho
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joystick;

        private Animator _animator;
        private Rigidbody _rigidBody;

        private readonly float speed = 3;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void Move()
        {
            _rigidBody.velocity = new(_joystick.Horizontal * speed, _rigidBody.velocity.y, _joystick.Vertical * speed);
        }

        public void ChangeRotation()
        {
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidBody.velocity);

                _animator.Play("Run");
            }
            else
            {
                _animator.Play("Idle");
            }
        }
    }
}

