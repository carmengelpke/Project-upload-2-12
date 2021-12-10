using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float increment, speed;
    public Vector2 targetPos;
    public static int collectedCoins = 0;
    private Vector2 newPos, newPos2;
    public GameObject Canvas1, Canvas2, Canvas3, CanvasMenu, CanvasHome, CanvasMessage, CanvasFinish, CanvasStat;
    public GameObject Coin1, Coin2, Baloon1, Baloon2, Baloon3;
    public Home home;
    public static int totalCorrect = 0;
    public static int totalNotCorrect = 0;
    private double val;
    public float timeLeft = 5.0f;
    private bool randomUpdate = false, updateCoins = false;
    public void Awake()
    {
        targetPos = transform.position;
    }
    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
        val = home.prob; // val defines the difficulty of the game (Easy, Medium, Hard)
        if (collectedCoins >= 5)
        {
            updateCoins = true;
            if (Random.value > val) // decides if either sound or picture is presented, based on difficulty
            {
                collectedCoins = 0;
                updateCoins = false;
                Canvas3.gameObject.SetActive(true);
            }
            else
            {
                collectedCoins = 0;
                updateCoins = false;
                Canvas2.gameObject.SetActive(true);
            }
        }

        if (totalNotCorrect == 5)
        {
            Baloon3.gameObject.SetActive(false);
        }
        if (totalNotCorrect == 10)
        {
            Baloon2.gameObject.SetActive(false);
        }
        if (totalNotCorrect == 15)
        {
            Baloon1.gameObject.SetActive(false);
        }
       
        if (totalCorrect >= 5)  // code to change te background after x correct answers
        {
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 5.0f;
                home.BG1.gameObject.SetActive(false);
                home.BG2.gameObject.SetActive(true); 
            }
        }
        else if (totalCorrect >= 10)
        {
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 5.0f;
                home.BG2.gameObject.SetActive(false);
                home.BG3.gameObject.SetActive(true); 
            }
        }
        else if (totalCorrect >= 15)
        {
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 5.0f;
                home.BG3.gameObject.SetActive(false);
                home.BG4.gameObject.SetActive(true); 
            }
        }
        else if (totalCorrect >= 20)
        {
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 5.0f;
                home.BG4.gameObject.SetActive(false);
                home.BG5.gameObject.SetActive(true); 
            }
        }
        else if (totalCorrect >= 25)
        {
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 5.0f;
                home.BG5.gameObject.SetActive(false);
                home.BG6.gameObject.SetActive(true); 
            }
        }
        else if (totalCorrect >= 30)
        {
            timeLeft -= Time.deltaTime;
            CanvasFinish.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasFinish.gameObject.SetActive(false);
                timeLeft = 5.0f;
                home.BG6.gameObject.SetActive(false);
                CanvasHome.gameObject.SetActive(true);
            }
        }
    }

    public void MoveLeft()
    {
        if (transform.position.x > -2)
        {
            targetPos = new Vector2(transform.position.x - increment, transform.position.y);
        }
    }
    public void MoveRight()
    {
        if (transform.position.x < 2)
        {
            targetPos = new Vector2(transform.position.x + increment, transform.position.y);
        }
    }

    public void Pause()
    {
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        Coin1.gameObject.SetActive(false);
        Coin2.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(true);
    }
    public void Resume()
    {
        Canvas1.gameObject.SetActive(true);
        Coin1.gameObject.SetActive(true);
        Coin2.gameObject.SetActive(true);
        Canvas2.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(false);
    }
    public void Home()
    {
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(false);
        CanvasHome.gameObject.SetActive(true);
    }
    public void Statistics()
    {
        CanvasStat.gameObject.SetActive(true);
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
