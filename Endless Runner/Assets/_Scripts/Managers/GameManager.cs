using TheCreators.PoolingSystem;
using TheCreators.Spawners;
using UnityEngine;
using UnityEngine.Events;

namespace TheCreators.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool _adDisplayed = false;
        [SerializeField] private UiManager _uiManager;
        [SerializeField] private GameObject _player;
        [SerializeField] private ObstacleSpawner _obstacleSpawner;
        public UnityEvent GameOverEvent;

        public static float GameSpeed { get; private set; }
        private Vector2 playerStartingPosition = new(-3.75f, -2f);
        private void Start()
        {
            Application.targetFrameRate = 60;
            GameSpeed = 6f;
        }
        public void OnPlayerDeath() => CheckIfShouldDisplayAd();
        public void OnPlayerCollisionWithObstacle() => GameSpeed = 0f;
        public void OnReward() => RestartGame();
        public void GameOver()
        {
            GameOverEvent.Invoke();
        }
        private void CheckIfShouldDisplayAd()
        {
            if (!_adDisplayed)
            {
                _uiManager.EnableRewardAdButton();
                _adDisplayed = true;
            }
            else
                GameOver();
        }
        private void RestartGame()
        {
            PooledObject[] obstaclesToClear = FindObjectsByType<PooledObject>(0);
            foreach (var item in obstaclesToClear)
            {
                item.gameObject.SetActive(false);
            }
            GameSpeed = 6f;
            _player.transform.position = playerStartingPosition;
            _player.SetActive(true);
            _obstacleSpawner.SpawnObstacle();
        }
    }
}