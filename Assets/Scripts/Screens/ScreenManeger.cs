using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManeger : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private LevelScreen _levelScreen;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    public VictoryScreen victoryScreen => _victoryScreen;
    public GameOverScreen gameOverScreen => _gameOverScreen;
    public StartScreen startScreen => _startScreen;
    public SettingsScreen settingsScreen => _settingsScreen;
    public GameScreen gameScreen => _gameScreen;
    public LevelScreen levelScreen => _levelScreen;

    
}
