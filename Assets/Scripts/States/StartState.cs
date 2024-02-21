using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State<Core>
{
    public StartState(Core core) : base(core) {}

    public override void OnEnter()
    {
        core.ScreenManeger.startScreen.Show(); // �������� ��������� ������
        core.ScreenManeger.startScreen.onStart += OnStart; // ������ ������� �� ������
        core.ScreenManeger.startScreen.onSetting += OnSetting;
        core.ScreenManeger.startScreen.onExit += OnExite;
    }

    private void OnStart() //������ 
    {
        ChangeState(new SelectLevelState(core));
    }
    private void OnSetting()
    {
        ChangeState(new SettingState(core));
    }
    private void OnExite()
    {

        Application.Quit();
    }

    public override void OnExit()
    {
        core.ScreenManeger.startScreen.onStart -= OnStart; // ������ ������� �� ������
        core.ScreenManeger.startScreen.onSetting -= OnSetting;
        core.ScreenManeger.startScreen.onExit -= OnExite;
        core.ScreenManeger.startScreen.Hide(); // �������� ��������� ������
    }
}
