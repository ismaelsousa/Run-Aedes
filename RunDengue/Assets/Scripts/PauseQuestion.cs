using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseQuestion : MonoBehaviour
{

    public GameObject lastQuestion;
    public GameObject localToSpawnQuestions;
    public GameObject score;
    public GameObject noQuestionButton;
    public GameObject yesQuestionButton;
    public GameObject butaoPause;
    public List<GameObject> questions;
    public int selectedQuestion = -1;

    public GameObject AlertQuestionRight;
    public GameObject AlertQuestionWrong;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void showItems()
    {
        score.SetActive(true);
        noQuestionButton.SetActive(false);
        yesQuestionButton.SetActive(false);
    }

    void cleanQuestion(bool delete) // if true it is because thats right answer!
    {
        if (delete)
        {
            Destroy(lastQuestion);
            questions.Remove(questions[selectedQuestion]);
            selectedQuestion = -1;
            AlertQuestionRight.SetActive(true);
        }
        else
        {
            Destroy(lastQuestion);
            selectedQuestion = -1;
            AlertQuestionWrong.SetActive(true);
        }
       

    }

    public void checkAnswer(string answer){

        // clean lastQuestion after check responses

        bool correct = questions[selectedQuestion].GetComponent<QuestionAnswer>().isTrue;
        if (answer == "yes") {
            if (correct) {
                Debug.Log("that's right!");
                showItems();
                pontuationController.pontuation += 10;
                PauseMenu.velocidadeJogo = 1f;
                cleanQuestion(true);
                return;

            };

        } else if (!correct) {
            Debug.Log("that's right!");
            showItems();
            pontuationController.pontuation += 10;
            PauseMenu.velocidadeJogo = 1f;
            cleanQuestion(true);
            return;
        };
        showItems();
        Debug.Log("that's wrong!");
        PauseMenu.GameIsPaused = false;
        PauseMenu.velocidadeJogo += 0.05f;       
        pontuationController.pontuation -= 5;
        cleanQuestion(false);
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
        if (questions.Count == 0) return;
        // Generate a random number between 0 and legth - 1

        selectedQuestion = Mathf.FloorToInt(Random.Range(0, questions.Count - 1));
        Debug.Log("random "+ selectedQuestion.ToString());


        // Create a new question
        lastQuestion = Instantiate(questions[selectedQuestion]) as GameObject;

        // set the position on the new object
        lastQuestion.transform.position =
            new Vector3(
                localToSpawnQuestions.transform.position.x,
                localToSpawnQuestions.transform.position.y,
                localToSpawnQuestions.transform.position.z);

        // put like son
        lastQuestion.transform.SetParent(localToSpawnQuestions.transform);

        butaoPause.SetActive(false);
        score.SetActive(false);
        noQuestionButton.SetActive(true);
        yesQuestionButton.SetActive(true);

        PauseMenu.velocidadeJogo = Time.timeScale;
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;

        GameObject[] aedes = GameObject.FindGameObjectsWithTag("Aedes");
        Debug.Log(aedes.Length);
        foreach (GameObject aede in aedes)
            Destroy(aede);

        GameObject[] pneus = GameObject.FindGameObjectsWithTag("Pneu");
        Debug.Log(pneus.Length);
        foreach (GameObject pneu in pneus)
            Destroy(pneu);
    }

    public void Continue()
    {
        AlertQuestionWrong.SetActive(false);
        AlertQuestionRight.SetActive(false);
        butaoPause.SetActive(true);
        PauseMenu.GameIsPaused = false;
        Time.timeScale = PauseMenu.velocidadeJogo;
    }
}
