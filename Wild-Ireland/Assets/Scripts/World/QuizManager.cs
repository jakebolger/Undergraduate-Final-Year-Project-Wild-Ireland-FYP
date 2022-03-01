using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    Question[] _questions = null;
    public Question[] Questions { get { return _questions; } }

    [SerializeField] QuizEvents events = null;


    private List<AnswerData> PickedAnswers = new List<AnswerData>();
    private List<int> FinishedQuestions = new List<int>();
    private int currentQuestion = 0;

    void Start()
    {
        LoadQuestions();

        foreach (var question in Questions)
        {
            Debug.Log(question.Info);
        }

        //Display();
    }

    public void EraseAnswers()
    {
        PickedAnswers = new List<AnswerData>();
    }
    

    void Display()
    {
        EraseAnswers();
        var question = GetRandomQuestion();

        if (events.UpdateQuestionUI != null)
        {
            events.UpdateQuestionUI(question);
        }
        else { Debug.LogWarning("something went wrong when trying to display new quesiton data"); }
    }

    Question GetRandomQuestion()
    {
        var randomIndex = GetRandomQUestionIndex();
        currentQuestion = randomIndex;

        return Questions[currentQuestion];

    }
    int GetRandomQUestionIndex()
    {
        var random = 0;
        if (FinishedQuestions.Count < Questions.Length)
        {
            do
            {
                random = UnityEngine.Random.Range(0, Questions.Length);
            } while (FinishedQuestions.Contains(random) || random == currentQuestion);
        }
        return random;
    }

    void LoadQuestions()
    {
        Object[] objs = Resources.LoadAll("Questions", typeof(Question));
        _questions = new Question[objs.Length];
        for(int i = 0; i < objs.Length; i++)
        {
            _questions[i] = (Question)objs[i];
        }
    }
}
