using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : BaseScreen
{
    [SerializeField] private Button _gamesBtn;
    [SerializeField] private Button _geographyBtn;
    [SerializeField] private Button _historyBtn;
    [SerializeField] private Button _returnBtn;


    public event Action onGames;
    public event Action onGeography;
    public event Action onHistory;
    public event Action onReturn;

    public override void Show()
    {
        base.Show();
        _gamesBtn.onClick.AddListener(OnGamesClick);
        _geographyBtn.onClick.AddListener(OnGeographyClick);
        _historyBtn.onClick.AddListener(OnHistoryClick);
        _returnBtn.onClick.AddListener(OnReturnClick);
    }

    private void OnGamesClick()
    {
        onGames?.Invoke();
    }

    private void OnGeographyClick()
    {
        onGeography?.Invoke();
    }

    private void OnHistoryClick()
    {
        onHistory?.Invoke();
    }

    private void OnReturnClick()
    {
        onReturn?.Invoke();
    }

    public override void Hide()
    {
        _gamesBtn.onClick.RemoveListener(OnGamesClick);
        _geographyBtn.onClick.RemoveListener(OnGeographyClick);
        _geographyBtn.onClick.RemoveListener(OnHistoryClick);
        _returnBtn.onClick.RemoveListener(OnReturnClick);
        base.Hide();
    }
}
