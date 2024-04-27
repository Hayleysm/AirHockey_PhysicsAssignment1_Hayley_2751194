using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float initialXpos, initialYpos;
    public bool isActive = false;
    public Rigidbody2D rigidB;
    public Bounds playerBounds;
    public Transform playerBoundaries;
    Vector2 initialPosition;
      public class Bounds
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
        initialPosition = rigidB.position;
      rigidB = GetComponent<Rigidbody2D>();
        playerBounds = new Bounds(playerBoundaries.GetChild(0).position.x,
                                  playerBoundaries.GetChild(1).position.x,
                                  playerBoundaries.GetChild(2).position.y,
                                  playerBoundaries.GetChild(3).position.y);
    }
 

  void OnMouseDown()
     {
         if (Input.GetMouseButtonDown(0))
         {
           //  Debug.Log("is working");
             isActive = true;
             Vector2 mousePos;
             mousePos = Input.mousePosition;
             mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             initialXpos = mousePos.x - this.transform.localPosition.x;
             initialYpos = mousePos.y - this.transform.localPosition.y;


         }
     }
     public void Update()
     {
         if (isActive == true)
         {
             Vector2 mousePos = Input.mousePosition; ;

             mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //this.gameObject.transform.position = new Vector2(mousePos.x - initialXpos, mousePos.y - initialYpos);
            Vector2 restriction = new Vector2(Mathf.Clamp(mousePos.x, playerBounds.Up,
                                             playerBounds.Down), Mathf.Clamp(mousePos.y,
                                             playerBounds.Right, playerBounds.Left));
            rigidB.MovePosition(restriction);

        }
    }
      public void OnMouseUp()
     {
         isActive = false;
     }
    public void ResetPos()
    {
        rigidB.position = initialPosition;
    }
}
