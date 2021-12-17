using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float increment, speed;
    public Vector2 targetPos;
    public static int collectedCoins = 0; 
    public static int coinCounter = 0;
    private int coinSaver1, coinSaver2;
    private Vector2 newPos, newPos2;
    public GameObject Canvas1, Canvas2, Canvas3, CanvasMenu, CanvasHome, CanvasMessage, CanvasFinish, CanvasStat, CanvasNoLives;
    public GameObject Coin1, Coin2, TxtBar1, TxtBar2, Baloon1, Baloon2, Baloon3;
    public Home home;
    public static int totalCorrect = 0;
    public static int totalNotCorrect = 0;
    private double val;
    public float timeLeft = 3.0f;
    private bool boolBackGround = false, updateCoins = false, boolBaloon = false;
    public static AudioSource audioSource;
    public AudioClip bgMusic;
    
    public void Awake()
    {
        targetPos = transform.position;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgMusic;
    }
    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        val = home.prob; // val defines the difficulty of the game (Easy, Medium, Hard)
        if (coinCounter >= 5)
        {
            updateCoins = true;
            if (Random.value > val) // decides if either sound or picture is presented, based on difficulty
            {
                updateCoins = false;
                Canvas3.gameObject.SetActive(true);
            }
            else
            {
                updateCoins = false;
                Canvas2.gameObject.SetActive(true);
            }
            coinCounter -= 5;
        }

        if (totalNotCorrect == 5) // removing 1 baloon every 5 wrong answer
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
            CanvasNoLives.gameObject.SetActive(true);
            Canvas1.gameObject.SetActive(false);
            Canvas2.gameObject.SetActive(false);
            Coin1.gameObject.SetActive(false);
            Coin2.gameObject.SetActive(false);
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                boolBaloon = true;
            }
            if (boolBaloon)
            {
                CanvasNoLives.gameObject.SetActive(false);
                timeLeft = 5.0f;
                CanvasHome.gameObject.SetActive(true);
            }
        }
       
        if (totalCorrect == 5)  // code to change te background after x correct answers
        {
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                boolBackGround = true;
            }
            if (boolBackGround)
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
                boolBackGround = true;
            }
            if (boolBackGround)
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
                boolBackGround = true;
            }
            if (boolBackGround)
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
                boolBackGround = true;
            }
            if (boolBackGround)
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
                boolBackGround = true;
            }
            if (boolBackGround)
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
            Canvas1.gameObject.SetActive(false);
            Canvas2.gameObject.SetActive(false);
            Coin1.gameObject.SetActive(false);
            Coin2.gameObject.SetActive(false);
            if (timeLeft <= 0.0f)
            {
                boolBackGround = true;
            }
            if (boolBackGround)
            {
                CanvasFinish.gameObject.SetActive(false);
                timeLeft = 3.0f;
                home.BG6.gameObject.SetActive(false);
                CanvasHome.gameObject.SetActive(true);
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
        Time.timeScale = 0;
        audioSource.Pause();
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        Coin1.gameObject.SetActive(false);
        Coin2.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        audioSource.Play();
        Canvas1.gameObject.SetActive(true);
        Coin1.gameObject.SetActive(true);
        Coin2.gameObject.SetActive(true);
        Canvas2.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(false);
    }
    public void Home()
    {
        Time.timeScale = 0;
        audioSource.Pause();
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(false);
        CanvasHome.gameObject.SetActive(true);
    }
    public void Statistics()
    {
        Time.timeScale = 0;
        audioSource.Pause();
        CanvasStat.gameObject.SetActive(true);
        Canvas1.gameObject.SetActive(false);
        Canvas2.gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
