using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public GameObject TxtLevel, Canvas, CanvasSetting, Coin, Coin2, Player;
    public GameObject TxtLetter;
    public double prob;
    public int level, letter, correct, notcorrect;
    public GameObject BG1, BG2, BG3, BG4, BG5, BG6;
    public  Sound sound;
    public ChangeCard changecard;

    public void Play()
    {
        Coin.gameObject.SetActive(true);
        Coin2.gameObject.SetActive(true);
        Player.gameObject.SetActive(true);
        
        switch (level)
        {
            case 1:
            {
                gameObject.SetActive(false);
                Canvas.gameObject.SetActive(true);
                BG1.gameObject.SetActive(true);
                prob = 0.9;
                break;
            }
            case 2:
            {
                gameObject.SetActive(false);
                Canvas.gameObject.SetActive(true);
                BG2.gameObject.SetActive(true);
                prob = 0.8;
                break;
            }
            case 3:
            {
                gameObject.SetActive(false);
                Canvas.gameObject.SetActive(true);
                BG3.gameObject.SetActive(true);
                prob = 0.7;
                break;
            }
            case 4:
            {
                gameObject.SetActive(false);
                Canvas.gameObject.SetActive(true);
                BG4.gameObject.SetActive(true);
                prob = 0.6;
                break;
            }
            case 5:
            {
                gameObject.SetActive(false);
                Canvas.gameObject.SetActive(true);
                BG5.gameObject.SetActive(true);
                prob = 0.5;
                break;
            }
            case 6:
            {
                gameObject.SetActive(false);
                Canvas.gameObject.SetActive(true);
                BG6.gameObject.SetActive(true);
                prob = 0.4;
                break;
            }
        }

        correct += sound.correct3;
        correct += changecard.correct2;
        notcorrect += sound.notcorrect3;
        notcorrect += changecard.notcorrect2;
    }
    public void LowerLevel()
    {
        if (level > 1)
        {
            level -= 1;
            TxtLevel.GetComponent<Text>().text = level.ToString();
        }
    }
    public void UpperLevel()
    {
        if (level < 6)
        {
            level += 1;
            TxtLevel.GetComponent<Text>().text = level.ToString();
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
    public void Setting()
    {
        CanvasSetting.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
