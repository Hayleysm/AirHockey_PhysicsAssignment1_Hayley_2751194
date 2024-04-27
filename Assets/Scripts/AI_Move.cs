using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class AI_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeed;
    private Rigidbody2D rigidB;
    private Vector2 initialPosition;
    public Rigidbody2D HockeyPuck;
    public Transform PlayerBoundaryHolder;
    private Bounds playerBoundary;
    public Transform PuckBoundaryHolder;
    private Bounds puckBoundary;
    private Vector2 targetPosition;
    class Bounds
    {
        public float Up, Down, Right, Left;
        public Bounds(float up, float down, float right, float left)
        {
            Up = up;
            Down = down;
            Right = right;
            Left = left;

        }
    }

    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        initialPosition = rigidB.position;
        playerBoundary = new Bounds(PlayerBoundaryHolder.GetChild(0).position.x,
                              PlayerBoundaryHolder.GetChild(1).position.x,
                              PlayerBoundaryHolder.GetChild(2).position.y,
                              PlayerBoundaryHolder.GetChild(3).position.y);
        puckBoundary = new Bounds(PlayerBoundaryHolder.GetChild(0).position.x,
                              PlayerBoundaryHolder.GetChild(1).position.x,
                              PlayerBoundaryHolder.GetChild(2).position.y,
                              PlayerBoundaryHolder.GetChild(3).position.y);



    }

    // Update is called once per frame
    void Update()
    {
        if (!HockeyPuckScript.Goal)
        {


            float movementspeed;
            if (HockeyPuck.position.y < playerBoundary.Down)
            {
                movementspeed = maxSpeed * Random.Range(0.1f, 0.5f);
                targetPosition = new Vector2(Mathf.Clamp(HockeyPuck.position.y,
                    playerBoundary.Left, playerBoundary.Right), initialPosition.x);


            }
            else
            {
                {
                    movementspeed = Random.Range(maxSpeed * 0.4f, maxSpeed);
                    targetPosition = new Vector2(Mathf.Clamp(HockeyPuck.position.x, playerBoundary.Up,
                        playerBoundary.Down), Mathf.Clamp(HockeyPuck.position.y, playerBoundary.Left, playerBoundary.Right));
                }
                rigidB.MovePosition(Vector2.MoveTowards(rigidB.position, targetPosition, movementspeed * Time.deltaTime));
            }

        }
    }
    public void ResetPosition()
    {
        rigidB.position = initialPosition;
    }
} 
