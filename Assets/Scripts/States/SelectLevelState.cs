using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelState : State<Core>
{
    public SelectLevelState(Core core) : base(core) {}

    public override void OnEnter()
    {
        core.ScreenManeger.levelScreen.Show(); // відкрили лвл
        core.ScreenManeger.levelScreen.onGames += OnGame;
        core.ScreenManeger.levelScreen.onGeography += OnGeography;
        core.ScreenManeger.levelScreen.onHistory += OnHistory;
        core.ScreenManeger.levelScreen.onReturn += OnReturn;
    }

    private void OnGame()
    {
        core.curentConfig = core.QuestionConfig.Find(n => n.index == 0);
        ChangeState(new PrepearLevelState(core));
    }
    private void OnGeography()
    {
        core.curentConfig = core.QuestionConfig.Find(n => n.index == 1);
        ChangeState(new PrepearLevelState(core));
    }

    private void OnHistory()
    {
        core.curentConfig = core.QuestionConfig.Find(n => n.index == 2);
        ChangeState(new PrepearLevelState(core));
    }

    private void OnReturn()
    {
        ChangeState(new StartState(core));
    }
    public override void OnExit()
    {
        core.ScreenManeger.levelScreen.onGames -= OnGame;
        core.ScreenManeger.levelScreen.onGeography -= OnGeography;
        core.ScreenManeger.levelScreen.onHistory -= OnHistory;
        core.ScreenManeger.levelScreen.onReturn -= OnReturn;
        core.ScreenManeger.levelScreen.Hide(); // відкрили лвл
    }
}
