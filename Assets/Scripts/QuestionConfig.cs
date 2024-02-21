using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QuestionConfig", menuName = "Question/Config")]
public class QuestionConfig : ScriptableObject
{
   public int index;
   public List<Question> questions;
   internal int correctAnswer;
}


[Serializable]
public class Question
{
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;

    public int corectAnswer;
    internal object answers;
    internal int correctAnswer;
}
