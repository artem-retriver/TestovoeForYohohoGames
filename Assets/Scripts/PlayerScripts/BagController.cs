using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Yohoho
{
    public class BagController : MonoBehaviour
    {
        [SerializeField] private List<ClaimbleObjects> _claimbleList;

        private PlayerController _playerController;
        private Sequence _sequence, _sequence1;
        
        private float YPos;
        public bool IsRemove;

        private void Start()
        {
            _playerController = GetComponentInParent<PlayerController>();
        }

        public void AddItemList(ClaimbleObjects claimbleObjects)
        {
            _sequence1 = DOTween.Sequence();

            _sequence1.AppendCallback(() => { _claimbleList.Add(claimbleObjects); });
            _sequence1.AppendCallback(() => { IsRemove = true; });

            _sequence1.AppendInterval(0.1f);

            _sequence1.AppendCallback(() => { claimbleObjects.transform.position = transform.position; });
            _sequence1.AppendCallback(() => 
            {
                if (_claimbleList.Count > 1)
                {
                    _claimbleList[^1].transform.DOMoveY(transform.position.y + YPos, 0.1f);

                    YPos += 0.25f;
                }             
            });
        }

        public void RemoveItemList(BuySpawnerPlaceController buySpawnerPlaceController)
        {
            /*if (IsRemove == true)
            {
                
            }*/
            
            _sequence = DOTween.Sequence();

            _sequence.AppendCallback(() =>
            {
                _claimbleList[^1].transform.SetParent(buySpawnerPlaceController.transform);
                _claimbleList[^1].transform.DOMove(buySpawnerPlaceController.transform.position, 0.5f);
            });
            _sequence.AppendCallback(() => { _playerController.DecreaseScore(); });
            _sequence.AppendCallback(() => { YPos = 0.25f; });
            _sequence.AppendCallback(() => { IsRemove = false; });

            _sequence.AppendInterval(0.15f);

            _sequence.AppendCallback(() => { _claimbleList[^1].DestroyObject(); });
            _sequence.AppendCallback(() => { _claimbleList.Remove(_claimbleList[^1]); });
            _sequence.AppendCallback(buySpawnerPlaceController.IncreaseCostPlace);
            _sequence.AppendCallback(CheckToStopRemoveList);

            _sequence.SetLoops(-1);
        }

        private void CheckToStopRemoveList()
        {
            if (_claimbleList.Count == 0)
            {
                
                _sequence.Kill();
            }
        }
    }
}