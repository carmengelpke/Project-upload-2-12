using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float increment, speed;
    public Vector2 targetPos;
    public static float collectedCoins = 0; 
    public static float coinCounter = 0;
    private float coinSaver1, coinSaver2;
    public List<float> possiblePosition;
    private Vector2 newPos, newPos2;
    public GameObject Canvas1, Canvas2, Canvas3, CanvasMenu, CanvasHome, CanvasMessage, CanvasFinish, CanvasStat;
    public GameObject Coin1, Coin2, TxtBar1, TxtBar2;
    public Home home;
    public static int totalCorrect = 0;
    public static int totalNotCorrect = 0;
    private double val;
    public float timeLeft = 3.0f;
    private bool randomUpdate = false;
    public void Awake()
    {
        targetPos = transform.position;
    }
    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
        val = home.prob; // val defines the difficulty of the game (Easy, Medium, Hard)
        if (coinCounter >= 5)
        {
            if (Random.value > val) // decides if either sound or picture is presented, based on difficulty
            {
                Canvas3.gameObject.SetActive(true);
            }
            else
            {
                Canvas2.gameObject.SetActive(true);
            }
            coinCounter -= 5;
        }
       
        if (totalCorrect == 5)  // code to change te background after x correct answers
        {

            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 3.0f;
                home.BG1.gameObject.SetActive(false);
                home.BG2.gameObject.SetActive(true);
                coinCounter = coinSaver1;
                collectedCoins = coinSaver2;
            }
        }
        else if (totalCorrect == 10)
        {
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 3.0f;
                home.BG2.gameObject.SetActive(false);
                home.BG3.gameObject.SetActive(true); 
                coinCounter = coinSaver1;
                collectedCoins = coinSaver2;
            }
        }
        else if (totalCorrect == 15)
        {
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 3.0f;
                home.BG3.gameObject.SetActive(false);
                home.BG4.gameObject.SetActive(true); 
                coinCounter = coinSaver1;
                collectedCoins = coinSaver2;
            }
        }
        else if (totalCorrect == 20)
        {
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 3.0f;
                home.BG4.gameObject.SetActive(false);
                home.BG5.gameObject.SetActive(true); 
                coinCounter = coinSaver1;
                collectedCoins = coinSaver2;
            }
        }
        else if (totalCorrect == 25)
        {
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            if (timeLeft <= 0.0f)
            {
                randomUpdate = true;
            }
            if (randomUpdate)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 3.0f;
                home.BG5.gameObject.SetActive(false);
                home.BG6.gameObject.SetActive(true); 
                coinCounter = coinSaver1;
                collectedCoins = coinSaver2;
            }
        }
        else if (totalCorrect == 30)
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
                timeLeft = 3.0f;
                home.BG6.gameObject.SetActive(false);
                CanvasHome.gameObject.SetActive(true);
                Coin1.gameObject.SetActive(false);
                Coin2.gameObject.SetActive(false);
            }
        }

        TxtBar1.GetComponent<TMP_Text>().text = "Gems collected: " + collectedCoins.ToString();
        TxtBar2.GetComponent<TMP_Text>().text = "Total correct: " + totalCorrect.ToString();
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
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Canvas1.gameObject.SetActive(true);
        Coin1.gameObject.SetActive(true);
        Coin2.gameObject.SetActive(true);
        Canvas2.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        int rand = Random.Range(0, possiblePosition.Count);
        int rand2 = Random.Range(0, possiblePosition.Count);
        newPos.x = possiblePosition.ElementAt(rand);
        newPos.y = 8f;
        newPos2.x = possiblePosition.ElementAt(rand2);
        newPos2.y = 8f;
        
        if (other.gameObject.name == "Coin")
        {
            collectedCoins+=1;
            coinCounter+=1;
            other.gameObject.transform.position = newPos;
        }
        if (other.gameObject.name == "Coin2")
        {
            collectedCoins+=1;
            coinCounter+=1;
            other.gameObject.transform.position = newPos2;
        }
    }
}
