using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Yohoho
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        
        private BagController _bagController;
        private MoveController _moveController;

        private float _YPositionForClaimbleObject;
        private int scoreCurrent;
        private bool isWin;

        private void Start()
        {
            _bagController = GetComponentInChildren<BagController>();
            _moveController = GetComponent<MoveController>();
        }

        private void FixedUpdate()
        {
            if (isWin == false)
            {
                _moveController.Move();
                _moveController.ChangeRotation();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ClaimbleObjects claimbleObjects))
            {
                IncreaseScore();
                claimbleObjects.JumpForPlayerBagPosition(_bagController.gameObject);
                _bagController.AddItemList(claimbleObjects);
            }

            if (other.gameObject.TryGetComponent(out BuySpawnerPlaceController buySpawnerPlaceController))
            {
                if (_bagController.IsRemove == true)
                {
                    Debug.Log("+");
                    _bagController.RemoveItemList(buySpawnerPlaceController);
                }
            }
        }

        private void IncreaseScore()
        {
            scoreCurrent++;
            _scoreText.text = scoreCurrent.ToString("0/36");
        }

        public void DecreaseScore()
        {
            scoreCurrent--;
            _scoreText.text = scoreCurrent.ToString("0/36");
        }
    }
}