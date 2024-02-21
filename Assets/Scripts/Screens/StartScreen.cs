using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : BaseScreen
{
    [SerializeField] private Button _startBtn; //задали кнопку старта
    [SerializeField] private Button _setttingBtn;
    [SerializeField] private Button _exitBtn;

    public event Action onStart; //створили собитія нажатої кнопки  старт
    public event Action onSetting;
    public event Action onExit;
    
    public override void Show()
    {
        base.Show();
        _startBtn.onClick.AddListener(OnStartClick); //добавляємо слухача на кнопку старт
        _setttingBtn.onClick.AddListener(OnSettingClick);
        _exitBtn.onClick.AddListener(OnExitClick);
    }

    private void OnStartClick() 
    {
        Debug.Log("Start");
        onStart?.Invoke(); // виклик собитія натиснутої кнопки старт
    }
    private void OnSettingClick()
    {
        onSetting?.Invoke();
    }

    private void OnExitClick()
    {
        onExit?.Invoke();
    }
    public override void Hide()
    {
        _startBtn.onClick.RemoveListener(OnStartClick); // забираємо слухача з кнопки старт
        _setttingBtn.onClick.RemoveListener(OnSettingClick);
        _exitBtn.onClick.RemoveListener(OnExitClick);
        base.Hide();
    }
}
    
    

