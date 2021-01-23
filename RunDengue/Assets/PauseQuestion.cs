using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseQuestion : MonoBehaviour
{

    public GameObject question;
    public GameObject noQuestionButton;
    public GameObject yesQuestionButton;
    public GameObject butaoPause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void yes() {
        Debug.Log("Press yes");
        butaoPause.SetActive(true);
        question.SetActive(false);
        noQuestionButton.SetActive(false);
        yesQuestionButton.SetActive(false);

        PauseMenu.GameIsPaused = false;
        Time.timeScale = PauseMenu.velocidadeJogo;
    }
    public void no() {
        Debug.Log("Press no");
        Time.timeScale = PauseMenu.velocidadeJogo;
        butaoPause.SetActive(true);
        question.SetActive(false);
        noQuestionButton.SetActive(false);
        yesQuestionButton.SetActive(false);

        PauseMenu.GameIsPaused = false;
        Time.timeScale = PauseMenu.velocidadeJogo;
    }
    public void showQuestion()
    {
        Debug.Log("AQUIIIIII");
        butaoPause.SetActive(false);
        question.SetActive(true);
        noQuestionButton.SetActive(true);
        yesQuestionButton.SetActive(true);

        PauseMenu.velocidadeJogo = Time.timeScale;
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;

    }
}
