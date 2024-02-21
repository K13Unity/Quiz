using System.Collections;
using UnityEngine;

public class InputState : State<Core>
{
    private GameScreen gameScreen;
    private int _index;
    private Coroutine _coroutine;

    public InputState(Core core, int correctAnswerId) : base(core)
    {
        _index = correctAnswerId;
        gameScreen = core.ScreenManeger.gameScreen;
    }

    public override void OnEnter()
    {
        gameScreen.Show();
        gameScreen.onReturn += OnReturn;

        foreach (var button in gameScreen.buttons)
        {
            button.AnswerButtonClicked += OnAnswerClick;
        }
    }

    private void OnAnswerClick(int index)
    {

        foreach (var answer in gameScreen.buttons)
        {
            answer.AnswerButtonClicked -= OnAnswerClick;
        }
        gameScreen.onReturn -= OnReturn;
        var button = gameScreen.buttons.Find(n => n.buttonIndex == index);

        if (index == _index)
        {
            button.SetButtonState(true);
            _coroutine = core.StartCoroutine(Delay(true));
        }
        else
        {
            button.SetButtonState(false);
            _coroutine = core.StartCoroutine(Delay(false));
        }
    }
    private void OnReturn()
    {
        core.questionNumbers.Clear();
        ChangeState(new StartState(core));
    }

    public override void OnExit()
    {
        foreach (var answer in gameScreen.buttons)
        {
            answer.AnswerButtonClicked -= OnAnswerClick;
        }

        if (_coroutine != null)
        {
            core.StopCoroutine(_coroutine);
        }
        gameScreen.onReturn -= OnReturn;
        gameScreen.Hide();
    }
    private IEnumerator Delay(bool value)
    {
        yield return new WaitForSeconds(1);
        if (value)
        {
            if (core.questionNumbers.Count >= core.QuestionConfig[0].questions.Count)
            {
                Debug.Log("Reached VictoryState");
                ChangeState(new VictoryState(core));
            }
            else
            {
                Debug.Log($"Moving to next question: {core.questionId}");
                ChangeState(new PrepearLevelState(core));
            }
        }
        else
        {
            core.questionId = 0;
            Debug.Log("Reached GameOverState");
            ChangeState(new GameOverState(core));
        }
    }
}