using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Yohoho
{
    public class BuySpawnerPlaceController : MonoBehaviour
    {
        [SerializeField] private SpawnerController _spawnerController;
        
        private Text _costPlace;

        private int costPlace;

        private void Start()
        {
            _costPlace = GetComponentInChildren<Text>();
        }

        public void IncreaseCostPlace()
        {
            costPlace++;
            _costPlace.text = costPlace.ToString("0/18");

            if (costPlace >= 18)
            {
                _spawnerController.CheckForShowNewSpawner();
                gameObject.SetActive(false);
            }
        }
    }
}