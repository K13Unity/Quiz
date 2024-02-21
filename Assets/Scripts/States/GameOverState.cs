
public class GameOverState : State<Core>
{
    public GameOverState(Core core) : base(core) {}

    public override void OnEnter()
    {
        core.ScreenManeger.gameOverScreen.Show();
        core.ScreenManeger.gameOverScreen.onReturn += OnReturn;
    }

    private void OnReturn()
    {
        ChangeState(new StartState(core));
    }

    public override void OnExit()
    {
        core.questionNumbers.Clear();
        core.ScreenManeger.gameOverScreen.onReturn -= OnReturn;
        core.ScreenManeger.gameOverScreen.Hide();
    }
}
