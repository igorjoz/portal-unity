using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool isGamePaused = false;

    bool endGame = false;
    bool isWin = false;

    public int points = 0;

    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    AudioSource audioSource;

    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    public TMP_Text timeText;
    public TMP_Text goldKeyText;
    public TMP_Text redKeyText;
    public TMP_Text greenKeyText;
    public TMP_Text crystalText;
    public Image snowFlake;
    public GameObject infoPanel;
    public TMP_Text pauseEnd;
    public TMP_Text reloadInfo;
    public TMP_Text useInfo;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        if (gameManager == null)
        {
            gameManager = this;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 5;
        }

        snowFlake.enabled = false;
        timeText.text = timeToEnd.ToString();
        infoPanel.SetActive(false);
        pauseEnd.text = "Pause";
        reloadInfo.text = "";
        SetUseInfo("");


        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper", 2, 1);
    }

    public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        PickUpCheck();

        if (endGame)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                Application.Quit();
            }
        }
    }

    void Stopper()
    {
        timeToEnd--;
        //Debug.Log("Time:" + timeToEnd + "s");

        timeText.text = timeToEnd.ToString();
        snowFlake.enabled = false;

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }

        if (endGame)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        PlayClip(pauseClip);
        infoPanel.SetActive(true);

        Debug.Log("Pause game");

        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        PlayClip(resumeClip);
        infoPanel.SetActive(false);

        Debug.Log("Resume game");

        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        infoPanel.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;

        if (isWin)
        {
            Debug.Log("You win!!! Reload?");
            pauseEnd.text = "You Win!!!";
            reloadInfo.text = "Reload? Y/N";
        }
        else
        {
            Debug.Log("You lost!!! Reload?");
            pauseEnd.text = "You Lose!!!";
            reloadInfo.text = "Reload? Y/N";
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        crystalText.text = points.ToString();
    }

    public void AddTime(int value)
    {
        timeToEnd += value;
        timeText.text = timeToEnd.ToString();
    }

    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        snowFlake.enabled = true;
        InvokeRepeating("Stopper", freezeTime, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Gold)
        {
            goldKey++;
            goldKeyText.text = goldKey.ToString();
        }
        else if (color == KeyColor.Red)
        {
            redKey++;
            redKeyText.text = redKey.ToString();
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
            greenKeyText.text = greenKey.ToString();
        }
    }

    void PickUpCheck()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red: " + redKey + " green: " + greenKey + " gold: " + goldKey);
            Debug.Log("Points: " + points);
        }
    }

    public void SetUseInfo(string info)
    {
        useInfo.text = info;
    }

    public void WinGame()
    {
        isWin = true;
        endGame = true;
    }
}
