using System.Collections.Generic;
using UnityEngine;


public class Core : MonoBehaviour
{
    [SerializeField] private ScreenManeger _screenManeger;
    [SerializeField] private List<QuestionConfig> _questions;

    public QuestionConfig curentConfig;
    public ScreenManeger ScreenManeger => _screenManeger;
    public List<QuestionConfig> QuestionConfig => _questions;

    public List<int> questionNumbers = new List<int>();

    private StateMachine<Core> _stateMachine;

    public int questionId;

    private void Start()
    {
        
        _stateMachine = new StateMachine<Core> (new StartState(this));
       
    }
}
