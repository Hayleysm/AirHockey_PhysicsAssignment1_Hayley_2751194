using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject GameCanvas;
    public GameObject RestartCanvas;
    public GameObject Win;
    public GameObject Lose;


    public ScoreSystem scoreSystem;
    public HockeyPuckScript hockeyPuck;
    public PlayerMovement playerMovement;
    public AI_Move aiMove;
    public CountDownTimer countDownTimer;
   


    public void DisplayRestart(bool notWin)
    {
        Time.timeScale = 0;
        GameCanvas.SetActive(false);
        RestartCanvas.SetActive(true);
        if (notWin)
        {
            Lose.SetActive(true);
            Win.SetActive(false);

        } else
        {
            Lose.SetActive(false);
            Win.SetActive(true);
        }
        

    }
    public void Restart()
    {
       Time.timeScale = 1;
        GameCanvas.SetActive(true);
        RestartCanvas.SetActive(false);
        scoreSystem.ResetPoints();
        hockeyPuck.ResetPuck();
       playerMovement.ResetPos();
        aiMove.ResetPosition();
      



    }
}
