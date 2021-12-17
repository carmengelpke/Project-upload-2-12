using UnityEngine;

public class SoundCorrect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioCorrect;
    public float timeLeft = 2.0f;
    public GameObject Coin1, Coin2;
    public bool update = true;

    public void Update()
    {
        timeLeft -= Time.deltaTime;
        if (update)
        {
            update = false;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioCorrect;
            audioSource.PlayOneShot(audioSource.clip);
        }
        if (timeLeft <= 0)
        {
            Coin1.gameObject.SetActive(true);
            Coin2.gameObject.SetActive(true); 
            gameObject.SetActive(false);
            timeLeft = 2.0f;
            update = true;
        }
    }
}
