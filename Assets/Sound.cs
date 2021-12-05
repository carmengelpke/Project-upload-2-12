using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray, audioClipArray2, audioClipArray3;
    public int[] valori, valori2, valori3;
    public int correct3 = 0, notcorrect3 = 0; 
    private int soft = 1, hard = 0, val, rand;
    public GameObject Timer;
    public GameObject Coin1, Coin2;
    public float timeLeft = 5.0f;
    public Home home;
    private bool randomUpdate = true;

    public void Update()
    {
        Coin1.gameObject.SetActive(false);
        Coin2.gameObject.SetActive(false);
        rand = 0;
        switch (home.letter)
        {
            case 1:
            { 
                ChangeSound();
                break;
            }
            case 2:
            {
                ChangeSound2();
                break;
            }
            case 3:
            {
                ChangeSound3();
                break;
            }
        }
        timeLeft -= Time.deltaTime;
        Timer.GetComponent<Text>().text = (Mathf.Round(timeLeft * 10.0f) * 0.1f).ToString();
        if (timeLeft <= 0.0f)
        {
            notcorrect3 += 1;
            gameObject.SetActive(false);
            timeLeft = 5.0f;
            randomUpdate = true;
            Coin1.gameObject.SetActive(true);
            Coin2.gameObject.SetActive(true);
        }
    }
    public void ChangeSound()
    {
        if (randomUpdate)
        {
            rand = Random.Range(0, audioClipArray.Length);
            randomUpdate = false;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClipArray[rand];
            audioSource.PlayOneShot(audioSource.clip);
            val = valori[rand];
        }
    }
    public void ChangeSound2()
    {
        if (randomUpdate)
        {
            rand = Random.Range(0, audioClipArray2.Length);
            randomUpdate = false;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClipArray2[rand];
            audioSource.PlayOneShot(audioSource.clip);
            val = valori2[rand];
        }
    }
    public void ChangeSound3()
    {
        if (randomUpdate)
        {
            rand = Random.Range(0, audioClipArray3.Length);
            randomUpdate = false;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClipArray3[rand];
            audioSource.PlayOneShot(audioSource.clip);
            val = valori3[rand];
        }
    }
    public void SoftSound()
    {
        if (val == soft)
            PlayerMovement.totalCorrect += 1;
        else 
            notcorrect3 += 1;
        gameObject.SetActive(false);
        timeLeft = 5.0f;
        randomUpdate = true;
        Debug.Log(correct3);
        Coin1.gameObject.SetActive(true);
        Coin2.gameObject.SetActive(true);
    }
    public void HardSound()
    {
        if (val == hard)
            PlayerMovement.totalCorrect += 1;
        else 
            notcorrect3 += 1;
        gameObject.SetActive(false);
        timeLeft = 5.0f;
        randomUpdate = true;
        Coin1.gameObject.SetActive(true);
        Coin2.gameObject.SetActive(true);
    }
}
