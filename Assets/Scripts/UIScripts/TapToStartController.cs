using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Yohoho
{
    public class TapToStartController : MonoBehaviour
    {
        [SerializeField] private SpawnerController _spawnerController;
        [SerializeField] private CameraPoolController _cameraPoolController;
        [SerializeField] private GameObject _gamePanel;
        
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(TapToStart);
        }

        private void TapToStart()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.AppendCallback(() => { gameObject.SetActive(false); });
            sequence.AppendCallback(() => { _cameraPoolController.StartMoveCameras(); });

            sequence.AppendInterval(3);

            sequence.AppendCallback(() => { _spawnerController.InstantiateNewClaimbleObjects(); });
            sequence.AppendCallback(() => { _gamePanel.SetActive(true); });
        }
    }
}