using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI TimerTXT;
    private float currentTime = 3;
    // private bool TimerisZero;
    public GameObject CounterCanvas;
    public GameObject PlayingObjects;
    private CountDownTimer countTimer;





    private void Update()
    {



        {
            CounterCanvas.SetActive(false);
            PlayingObjects.SetActive(true);


            while (currentTime > 0)
            {
                currentTime -= 1 * Time.deltaTime;
                TimerTXT.text = currentTime.ToString("0");
                CounterCanvas.SetActive(true);
                PlayingObjects.SetActive(false);




                break;
            }



        } 
    }

      
    }
