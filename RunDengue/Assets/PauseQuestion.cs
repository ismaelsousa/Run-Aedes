using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseQuestion : MonoBehaviour
{

    public GameObject question;
    public GameObject lastQuestion;
    public GameObject localToSpawnQuestions;
    public GameObject score;
    public GameObject noQuestionButton;
    public GameObject yesQuestionButton;
    public GameObject butaoPause;
    public List<GameObject> questions;
    public int selectedQuestion = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Debug.ClearDeveloperConsole();
       // Debug.Log(Random.Range(0, 2));
    }

    void showItems()
    {
        score.SetActive(true);
        butaoPause.SetActive(true);
        question.SetActive(false);
        noQuestionButton.SetActive(false);
        yesQuestionButton.SetActive(false);
    }

    void cleanQuestion(bool delete)
    {
        if (delete)
        {
            Destroy(lastQuestion);
            questions.Remove(questions[selectedQuestion]);
            selectedQuestion = -1;
        }
        else
        {
            Destroy(lastQuestion);
            selectedQuestion = -1;
        }
       

    }
    public void checkAnswer(string answer){

        // clean lastQuestion after check responses

        bool correct = questions[selectedQuestion].GetComponent<QuestionAnswer>().isTrue;
        if (answer == "yes") {
            if (correct) {
                Debug.Log("ACertou");
                showItems();
                PauseMenu.GameIsPaused = false;
                Time.timeScale = PauseMenu.velocidadeJogo;
                cleanQuestion(true);
                return;

            };

        } else if (!correct) {
            Debug.Log("ACertou");
            showItems();
            PauseMenu.GameIsPaused = false;
            Time.timeScale = PauseMenu.velocidadeJogo;
            cleanQuestion(true);
            return;
        };
        showItems();
        PauseMenu.GameIsPaused = false;
        PauseMenu.velocidadeJogo += 0.05f;
        Time.timeScale = PauseMenu.velocidadeJogo;
        Debug.Log("Errou");
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
       // question.SetActive(true);
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
}
