using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private int _buttonIndex;
    [SerializeField] private Image _positiveImage;
    [SerializeField] private Image _negativeImage;
    [SerializeField] private TextMeshProUGUI _text;

    public int buttonIndex => _buttonIndex;

    public event Action<int> AnswerButtonClicked;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }
    private void OnButtonClick()
    {
        AnswerButtonClicked?.Invoke(buttonIndex);
    }

    public void SetButtonState(bool state)
    {
        if (state)
        {
            _positiveImage.gameObject.SetActive(true);
        }
        else
        {
            _negativeImage.gameObject.SetActive(true);
        }
    }

    public void Init (string answer)
    {
        _positiveImage.gameObject.SetActive(false);
        _negativeImage.gameObject.SetActive(false);
        _text.text = answer;
    }
}
