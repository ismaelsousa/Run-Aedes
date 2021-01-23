using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseQuestion : MonoBehaviour
{

    public GameObject question;
    public GameObject score;
    public GameObject noQuestionButton;
    public GameObject yesQuestionButton;
    public GameObject butaoPause;
    public GameObject[] questions;
    public int selectedQuestion = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkAnswer(string answer){
        bool correct = questions[selectedQuestion].GetComponent<QuestionAnswer>().isTrue;
        if (answer == "yes") {
            if (correct) {
                Debug.Log("ACertou");
                return;
                score.SetActive(true);
                butaoPause.SetActive(true);
                question.SetActive(false);
                noQuestionButton.SetActive(false);
                yesQuestionButton.SetActive(false);

                PauseMenu.GameIsPaused = false;
                Time.timeScale = PauseMenu.velocidadeJogo;
            };

        } else if (!correct) {
            Debug.Log("ACertou");
            return;
        };

        Debug.Log("Errou");
    }

    public void yes() {
        Debug.Log("Press yes");
        checkAnswer("yes");      
    }
    public void no() {
        Debug.Log("Press no");
        checkAnswer("no");
       
    }

    public void showQuestion()
    {
        Debug.Log("AQUIIIIII");
        butaoPause.SetActive(false);
        question.SetActive(true);
        score.SetActive(false);
        noQuestionButton.SetActive(true);
        yesQuestionButton.SetActive(true);

        PauseMenu.velocidadeJogo = Time.timeScale;
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;

    }
}
