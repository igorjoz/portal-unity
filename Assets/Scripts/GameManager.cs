using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 5;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        PickUpCheck();
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time:" + timeToEnd + "s");

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
        Debug.Log("Pause game");
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
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

        if (isWin)
        {
            Debug.Log("You win!!! Reload?");
        }
        else
        {
            Debug.Log("You lost!!! Reload?");
        }
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }

    public void AddTime(int value)
    {
        timeToEnd += value;
    }

    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime, 1);
    }

    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Gold)
        {
            goldKey++;
        }
        else if (color == KeyColor.Red)
        {
            redKey++;
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
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
}
