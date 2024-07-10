using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Yohoho
{
    public class SpawnerController : MonoBehaviour
    {
        //[SerializeField] private Animator _animator;
        [SerializeField] private ClaimbleObjects _claimbleObjects;
        [SerializeField] private GameObject _instantiatePosition;
        [SerializeField] private GameObject _fvxToShowObject;
        [SerializeField] private GameObject[] _canvasObjects;
        [SerializeField] private List<GameObject> _positionNewObjects;

        private Sequence _sequence;
        public Text _scoreObject;
        private int countNewObjects;
        
        private void Start()
        {
            //_scoreObject = GetComponentInChildren<Text>();

            //InstantiateNewClaimbleObjects();
        }

        public void InstantiateNewClaimbleObjects()
        {
            _sequence = DOTween.Sequence();

            //_sequence.AppendCallback(() => { _animator.enabled = true; });
            
            _sequence.AppendCallback(() =>
            {
                foreach (var t in _canvasObjects)
                {
                    t.gameObject.SetActive(true);
                }
            });
            
            _sequence.AppendInterval(2);

            _sequence.AppendCallback(() =>
            {
                var NewClaimbleObject = Instantiate(_claimbleObjects, _positionNewObjects[countNewObjects].transform, true);
                NewClaimbleObject.gameObject.SetActive(true);
                NewClaimbleObject.transform.position = _instantiatePosition.transform.position;
                NewClaimbleObject.transform.DOMove(_positionNewObjects[countNewObjects].transform.position, 1);
                NewClaimbleObject.OnBoxCollider();
            });

            _sequence.AppendCallback(CheckForStopSpawnNewObjects);

            _sequence.SetLoops(-1);
        }

        private void CheckForStopSpawnNewObjects()
        {
            countNewObjects++;
            _scoreObject.text = countNewObjects.ToString("0/18");
            
            if (countNewObjects >= 18)
            {
                //_animator.enabled = false;

                foreach (var t in _canvasObjects)
                {
                    t.SetActive(false);
                }
                
                _sequence.Kill();
            }
        }
        
        public void CheckForShowNewSpawner()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.AppendCallback(() => { transform.DOMoveY(4.1f, 3); });

            sequence.AppendCallback(() => { _fvxToShowObject.SetActive(true); });

            sequence.AppendInterval(4);
            
            sequence.AppendCallback(() => { _fvxToShowObject.SetActive(false); });
            
            /*sequence.AppendCallback(() =>
            {
                foreach (var t in _canvasObjects)
                {
                    t.gameObject.SetActive(true);
                }
            });*/

            sequence.AppendCallback(InstantiateNewClaimbleObjects);
        }
    }
}