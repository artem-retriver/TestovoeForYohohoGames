using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Yohoho
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _panelObjects;
        [SerializeField] private GameObject[] _tutorialObjects;
        [SerializeField] private GameObject _showGame;
        [SerializeField] private GameObject _hideGame;

        private int isTutorial;

        private void Start()
        {
            ShowGame();
            ShowTutorialPanel();
        }

        public void TutorialNextButton()
        {
            foreach (var t in _tutorialObjects)
            {
                t.SetActive(false);
            }
            
            switch (isTutorial)
            {
                case 0:
                    _tutorialObjects[1].SetActive(true);
                    break;
                case 1:
                    _tutorialObjects[2].SetActive(true);
                    break;
                case 2:
                    _tutorialObjects[3].SetActive(true);
                    break;
                case 3:
                    ShowTapToStartPanel();
                    break;
            }
            
            isTutorial++;
        }

        private void ShowTutorialPanel()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.AppendInterval(3);
            
            sequence.AppendCallback(() => { _panelObjects[2].SetActive(true); });
        }

        private void ShowTapToStartPanel()
        {
            _panelObjects[0].SetActive(true);
        }

        private void ShowGame()
        {
            ShowHideBase(_showGame);
        }
        
        private void HideGame()
        {
            ShowHideBase(_hideGame);
        }

        private void ShowHideBase(GameObject showHideGameObject)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.AppendCallback(() => { showHideGameObject.SetActive(true); });

            sequence.AppendInterval(3);
            
            sequence.AppendCallback(() => { showHideGameObject.SetActive(false); });
        }
    }
}