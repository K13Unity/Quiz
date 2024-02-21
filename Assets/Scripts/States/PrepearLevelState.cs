
using UnityEngine;

public class PrepearLevelState : State<Core>
{
    public PrepearLevelState(Core core) : base(core) 
    {
        
    }

    public override void OnEnter()
    {
        SetRandomIndex();
        SetupQuestion(core.questionId);
    }

    private void SetupQuestion(int questionId)
    {
        var question = core.curentConfig.questions[questionId].question;
        core.ScreenManeger.gameScreen.Init(question);

        for (int i = 0; i < core.ScreenManeger.gameScreen.buttons.Count; i++)
        {
            var button = core.ScreenManeger.gameScreen.buttons.Find(n => n.buttonIndex == i + 1);
            string answers = "";

            if(i == 0)
            {
                answers = core.curentConfig.questions[questionId].answerA;
            }
            if(i == 1)
            {
                answers = core.curentConfig.questions[questionId].answerB;
            }
            if(i == 2)
            {
                answers = core.curentConfig.questions[questionId].answerC;
            }
            button.Init(answers);
            
        }
        ChangeState(new InputState(core, core.curentConfig.questions[questionId].corectAnswer));
    }
    private void SetRandomIndex()
    {
        while (core.questionNumbers.Count < core.QuestionConfig[0].questions.Count)
        {
            int number = Random.Range(0, core.QuestionConfig[0].questions.Count);
            if (!core.questionNumbers.Contains(number))
            {
                core.questionNumbers.Add(number);
                core.questionId = number;
                break;
            }
        }
    }
}
