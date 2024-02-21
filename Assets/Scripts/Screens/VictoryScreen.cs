using System;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : BaseScreen
{
    [SerializeField] private Button _returnBtn;

    public event Action onReturn;

    public override void Show()
    {
        base.Show();
        _returnBtn.onClick.AddListener(OnReturnClick);
    }

    private void OnReturnClick()
    {
        onReturn?.Invoke();
    }
    public override void Hide()
    {
        _returnBtn.onClick.RemoveListener(OnReturnClick);
        base.Hide();
    }
}
