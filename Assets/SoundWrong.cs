using UnityEngine;

public class SoundWrong : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioWrong;
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
            audioSource.clip = audioWrong;
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
