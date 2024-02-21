using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BaseScreen
{
    [SerializeField] private Button _returnBtn;
    [SerializeField] private TextMeshProUGUI _questonTxt;
    [SerializeField] private List<AnswerButton> _buttons;

    public event Action onReturn;
    public List<AnswerButton> buttons => _buttons;

    public override void Show()
    {
        base.Show();
        _returnBtn.onClick.AddListener(OnReturnClick);
    }

    public void Init(string question)
    {
        _questonTxt.text = question;
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
