// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
//
// Copyright (c) 2019 Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Creator Agreement, located
// here: https://id.magicleap.com/creator-terms
//
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

namespace MagicLeap
{
    /// <summary>
    /// This class handles the functionality of updating the bounding box
    /// for the planes query params through input. This class also updates
    /// the UI text containing the latest useful info on the planes queries.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField, Space, Tooltip("Text to display countdown to start the level")]
        private Text _countDownText = null;

        private GravePlacer _gravePlacer;
        
        private enum GameModes
        {
            Intro,
            Scan,
            Start,
            Play,
            End
        };

        private GameModes _currentGameMode = GameModes.Intro;
        
        private Camera _camera;

        void SetGameModeText()
        {
            _countDownText.text =string.Format("Game Mode: {0}", _currentGameMode.ToString());
        }
        

        /// <summary>
        /// Check editor set variables for null references.
        /// </summary>
        void Awake()
        {
            if (_countDownText == null)
            {
                Debug.LogError("Error: GameManager._countDownText is not set, disabling script.");
                enabled = false;
                return;
            }
            else
            {
                SetGameModeText();
            }
            
            _camera = Camera.main;

            _gravePlacer = GetComponent<GravePlacer>();
            if (_gravePlacer == null)
            {
                Debug.LogError("Error: GameManager._gravePlacer is not set, disabling script.");
                enabled = false;
                return;
            }
        }

        void Update()
        {
            switch (_currentGameMode)
            {
                case GameModes.Intro:
                    // TODO wait for intro to finish
                    _currentGameMode = GameModes.Scan;
                    break;
                case GameModes.Scan:
                    if (_gravePlacer.GravesPlaced())
                    {
                        _currentGameMode = GameModes.Start; 
                    }
                    break;
                case GameModes.Start:
                    // TODO run game mode
                    _currentGameMode = GameModes.Play;
                    break;
                case GameModes.Play:
                    // TODO wait for game end conditions
                    _currentGameMode = GameModes.End;
                    break;
                case GameModes.End:
                    // TODO test for user restarting game
                    break;
            }

            SetGameModeText();
        }
    }
}
