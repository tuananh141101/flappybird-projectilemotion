using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BirdMovement playerBird;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject gameStart;
    private int score;

    private void Awake()
    {
        //Application.targetFrameRate = 120; //loc fps o 60
        Pause(); //moi play se chua chay game voi
    }

    public void Play() 
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        gameStart.SetActive(false);

        Time.timeScale = 1f;
        playerBird.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>(); //check gameobj nao gan script pipes
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        } 
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        playerBird.enabled = false; //tat toan bo script(update,fixupdate se khong chay)
    }

    public void GameOver() 
    {
        gameOver.SetActive(true); //Hien UI len
        playButton.SetActive(true);//Hien UI len
        gameStart.SetActive(false);
        Pause();
    }

    public void Increscore() 
    {
        score++;  
        scoreText.text = score.ToString();  
    }
}
