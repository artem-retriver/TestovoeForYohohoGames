using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Yohoho
{
    public class ClaimbleObjects : MonoBehaviour
    {
        private BoxCollider _boxCollider;
        private ParticleSystem[] _particleSystems;

        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _particleSystems = GetComponentsInChildren<ParticleSystem>();
        }

        public void OnBoxCollider()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.AppendInterval(1);
            
            sequence.AppendCallback(() => { _boxCollider.enabled = true; });
        }

        public void JumpForPlayerBagPosition(GameObject bagPosition)
        {
            foreach (var t in _particleSystems)
            {
                t.gameObject.SetActive(false);
            }
            
            _boxCollider.enabled = false;
            transform.DOJump(bagPosition.transform.position, 2, 0, 0.1f);
            transform.SetParent(bagPosition.transform);
        }

        public void DestroyObject()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.AppendInterval(0.2f);

            sequence.AppendCallback(() => { Destroy(gameObject); });
        }
    }
}