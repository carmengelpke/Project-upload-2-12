using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public GameObject StatCorrect, StatNotCorrect, CanvasHome, Coin1, Coin2;
    public void Update()
    {
        Coin1.gameObject.SetActive(false);
        Coin2.gameObject.SetActive(false);
        StatNotCorrect.GetComponent<Text>().text = (PlayerMovement.totalNotCorrect).ToString();
        StatCorrect.GetComponent<Text>().text = (PlayerMovement.totalCorrect).ToString();
    }
    public void Home()
    {
        gameObject.SetActive(false);
        CanvasHome.gameObject.SetActive(true);
    }
}
