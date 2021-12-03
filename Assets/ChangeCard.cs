using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChangeCard : MonoBehaviour
{
    public int correct2 = 0, notcorrect2 = 0;
    public Sprite[] sprite, sprite2, sprite3;
    public String[] names, names2, names3;
    public int[] valori, valori2, valori3;
    private int soft = 1, hard = 0;
    public int val, rand2, rand;
    public GameObject Photo, Txt, Timer;
    public GameObject Coin1, Coin2;
    public float timeLeft = 5.0f;
    public Home home;
    public void Update()
    {
        Coin1.gameObject.SetActive(false);
        Coin2.gameObject.SetActive(false);
        switch (home.letter)
        {
            case 1:
            { 
                ChangeImg();
                break;
            }
            case 2:
            {
                ChangeImg2();
                break;
            }
            case 3:
            {
                ChangeImg3();
                break;
            }
        }
        timeLeft -= Time.deltaTime;
        Timer.GetComponent<Text>().text = (Mathf.Round(timeLeft * 10.0f) * 0.1f).ToString();
        if (timeLeft <= 0.0f)
        {
            notcorrect2 += 1;
            gameObject.SetActive(false);
            timeLeft = 5.0f;
            Coin1.gameObject.SetActive(true);
            Coin2.gameObject.SetActive(true);
        }
    }
    public void ChangeImg()
    {
        rand2 = (int) Math.Round(Random.value);
        rand = rand2 * sprite.Length;
        Photo.GetComponent<Image>().overrideSprite = sprite[rand];
        Txt.GetComponent<Text>().text = names[rand];
        val = valori[rand];
    }
    public void ChangeImg2()
    {
        rand2 = (int) Math.Round(Random.value);
        rand = rand2 * sprite.Length;
        Photo.GetComponent<Image>().overrideSprite = sprite2[rand];
        Txt.GetComponent<Text>().text = names2[rand];
        val = valori2[rand];
    }
    public void ChangeImg3()
    {
        rand2 = (int) Math.Round(Random.value);
        rand = rand2 * sprite.Length;
        Photo.GetComponent<Image>().overrideSprite = sprite3[rand];
        Txt.GetComponent<Text>().text = names3[rand];
        val = valori3[rand];
    }
    public void SoftSound()
    {
        if (val == soft)
            correct2 += 1;
        else 
            notcorrect2 += 1;
        rand2 = 0;
        gameObject.SetActive(false);
        timeLeft = 5.0f;
        Coin1.gameObject.SetActive(true);
        Coin2.gameObject.SetActive(true);
    }
    public void HardSound()
    {
        if (val==hard)
            correct2 += 1;
        else 
            notcorrect2 += 1;
        rand2 = 0;
        gameObject.SetActive(false);
        timeLeft = 5.0f;
        Coin1.gameObject.SetActive(true);
        Coin2.gameObject.SetActive(true);
    }
}
