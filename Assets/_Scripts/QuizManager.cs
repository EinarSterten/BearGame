using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField] GameObject[] questions;
    [SerializeField] GameObject loseScreen;

    int currentQuestion;

    public void CorrectAnswer()
    {
        if (currentQuestion + 1 != questions.Length)
        {
            questions[currentQuestion].SetActive(false);

            currentQuestion++;
            questions[currentQuestion].SetActive(true);
        }
    }

    public void WrongAnswer()
    {
        questions[currentQuestion].SetActive(false);

        loseScreen.SetActive(true);
    }

    public void Retry()
    {
        questions[currentQuestion].SetActive(false);

        currentQuestion = 0;

        questions[currentQuestion].SetActive(true);

        loseScreen.SetActive(false);
    }

    public void LoadSceneByName(string Overworld_Prototype)
    {
        SceneManager.LoadScene(Overworld_Prototype);
    }
}
