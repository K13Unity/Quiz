
public class VictoryState : State<Core>
{
    public VictoryState (Core core) : base(core) { }
    public override void OnEnter()
    {
        core.ScreenManeger.victoryScreen.Show();
        core.ScreenManeger.victoryScreen.onReturn += OnReturn;
    }

    private void OnReturn()
    {
        ChangeState(new StartState(core));
    }

    public override void OnExit()
    {
        core.questionNumbers.Clear();
        core.ScreenManeger.victoryScreen.onReturn -= OnReturn;
        core.ScreenManeger.victoryScreen.Hide();
    }
}
