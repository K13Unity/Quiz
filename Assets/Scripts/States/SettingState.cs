using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingState : State<Core>
{
    public SettingState(Core core) : base(core) {}

    public override void OnEnter()
    {
        core.ScreenManeger.settingsScreen.Show();
        core.ScreenManeger.settingsScreen.onReturn += OnReturn;
    }

    private void OnReturn() 
    { 
        ChangeState(new StartState(core));
    }

    public override void OnExit()
    {
        core.ScreenManeger.settingsScreen.onReturn -= OnReturn;
        core.ScreenManeger.settingsScreen.Hide();
    }
}

