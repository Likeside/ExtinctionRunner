using System;
using ExtinctionRunner;
using ExtinctionRunner.Views;
using SavingGame;
using UnityEngine;

namespace Controllers
{
    public class GameOverController
    {
        private InputController _inputController;
        private PlayerController _playerController;
        private PlayerHpController _playerHpController;
        private AsteroidsController _asteroidsController;
        private GameOverPanelView _gameOverPanelView;
        private static int _numberOfTimesDied = 0;

        public GameOverController(PlayerController playerController, PlayerHpController playerHpController, InputController inputController, AsteroidsController asteroidsController)
        {
            _inputController = inputController;
            _playerController = playerController;
            _playerHpController = playerHpController;
            _asteroidsController = asteroidsController;
            _gameOverPanelView = GameObject.FindObjectOfType<GameOverPanelView>();
            _gameOverPanelView.gameObject.SetActive(false);


            _playerController.OnPlayerSunk += GameOver;
            _playerHpController.OnPlayerDead += GameOver;
        }


        private void GameOver()
        {
            _numberOfTimesDied += 1;
            AudioController.StopRunSound(_playerController._playerView.runAudioSource);
            _inputController.movementEnabled = false;
            _asteroidsController.isSpawning = false;
            _gameOverPanelView.gameObject.SetActive(true);
            _gameOverPanelView._scoreAmount.text = ScoreManager.CurrentScore.ToString();
            HighScoreManager.SetHighScore(ScoreManager.CurrentScore);
            SaveSystem.SaveGame();
            ScoreManager.InitializeScore();
            if (_numberOfTimesDied % 3 == 0)
            {
                AdsManager.ShowInterstitialAd();
            }
            _playerController.OnPlayerSunk -= GameOver;
            _playerHpController.OnPlayerDead -= GameOver;

        }

        
    }
}