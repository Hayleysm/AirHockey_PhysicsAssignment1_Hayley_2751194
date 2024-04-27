using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ScoreSystem;

public class ScoreSystem : MonoBehaviour
{
    public enum Points
    {
        PlayerPoints, AIPoints
    }

    public TextMeshProUGUI PlayerPointsTXT, AIPointsTXT;
    private int aiPoints, playerPoints;
    public UI ui;
    public int maxPoints;
    private int AiPoints
    {
        get { return aiPoints; }
        set
        {
            aiPoints = value;
            if (value == maxPoints)
            {
                ui.DisplayRestart(true);
            }
        }
    }
    private int PlayerPoints
    {
        get { return playerPoints; }
        set
        {
            playerPoints = value;
            if (value == maxPoints)
            {
                ui.DisplayRestart(false);
            }
        }
    }
    public void Increment(Points whatPoint)
    {


        if (whatPoint == Points.AIPoints)
        {
            AIPointsTXT.text = (++AiPoints).ToString();
        }
        else
        {
            PlayerPointsTXT.text = (++PlayerPoints).ToString();
        }

    }
    public void ResetPoints()
    {
        AiPoints = 0;
        PlayerPoints = 0;
        AIPointsTXT.text = "0";
        PlayerPointsTXT.text = "0";
    }
}

