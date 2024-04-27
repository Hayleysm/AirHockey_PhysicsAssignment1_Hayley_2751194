using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockeyPuckScript : MonoBehaviour
{
    // Start is called before the first frame update

    public ScoreSystem scoreSystem ;
    public static bool Goal { get;private set; }
    private Rigidbody2D rigidB;
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        Goal = false;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Goal)
        {
            if(other.tag == "AIGoal")
            {
                scoreSystem.Increment(ScoreSystem.Points.PlayerPoints);
                Goal = true;
                StartCoroutine(ResetHockeyPuck());

            }
            else if (other.tag == "PlayerGoal")
            {

                scoreSystem.Increment(ScoreSystem.Points.AIPoints);
                Goal = true;
                StartCoroutine(ResetHockeyPuck());

            }
        }
    }
    private IEnumerator ResetHockeyPuck()
    { 
        yield return new WaitForSecondsRealtime(1);
        Goal = false;
        rigidB.velocity = rigidB.position = new Vector2 (0, 0);
    }
    public void ResetPuck()
    {
        rigidB.position = new Vector2(0,0);
    }
} 
  
