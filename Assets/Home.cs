using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public GameObject Canvas, CanvasStat, Coin, Coin2, Player;
    public GameObject TxtLetter, TxtLevel;
    public double prob;
    public int level, letter;
    public GameObject BG1, BG2, BG3, BG4, BG5, BG6;

    public void Play()
    {
        Coin.gameObject.SetActive(true);
        Coin2.gameObject.SetActive(true);
        Player.gameObject.SetActive(true);
        switch (level)
        {
            case 1: //Easy
            {
                gameObject.SetActive(false);
                Canvas.gameObject.SetActive(true);
                BG1.gameObject.SetActive(true);
                prob = 0.9; //90% of words are written
                break;
            }
            case 2: //Medium
            {
                gameObject.SetActive(false);
                Canvas.gameObject.SetActive(true);
                BG1.gameObject.SetActive(true);
                prob = 0.7; //70% of words are written
                break;
            }
            case 3: //Hard
            {
                gameObject.SetActive(false);
                Canvas.gameObject.SetActive(true);
                BG1.gameObject.SetActive(true);
                prob = 0.5; //50% of words are written
                break;
            }
        }
    }

    public void LowerLevel()
    {
        if (level > 1)
        {
            level -= 1;
            if (level == 1)
                TxtLevel.GetComponent<Text>().text = "Easy";
            if (level == 2)
                TxtLevel.GetComponent<Text>().text = "Medium";
        }
    }
    public void UpperLevel()
    {
        if (level < 3)
        {
            level += 1;
            if (level == 3)
                TxtLevel.GetComponent<Text>().text = "Hard";
            if (level == 2)
                TxtLevel.GetComponent<Text>().text = "Medium";
        }
    }
    public void LowerLetter()
    {
        if (letter > 1)
        {
            letter -= 1;
            if (letter == 1) 
                TxtLetter.GetComponent<Text>().text = "C";
            if (letter == 2)
                TxtLetter.GetComponent<Text>().text = "G";
        }
    }
    public void UpperLetter()
        {
            if (letter < 3)
            {
                letter += 1;
                if (letter == 3) 
                    TxtLetter.GetComponent<Text>().text = "S";
                if (letter == 2)
                    TxtLetter.GetComponent<Text>().text = "G";
            }
        }
    public void Statistics()
    {
        gameObject.SetActive(false);
        CanvasStat.gameObject.SetActive(true);
    }
}
