using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Collision : MonoBehaviour
{
    public List<float> possiblePosition;
    private Vector2 newPos, newPos2;
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
            PlayerMovement.collectedCoins += 1;
            PlayerMovement.coinCounter += 1;
            other.gameObject.transform.position = newPos;
        }
        if (other.gameObject.name == "Coin2")
        {
            PlayerMovement.collectedCoins += 1;
            PlayerMovement.coinCounter += 1;
            other.gameObject.transform.position = newPos2;
        }
    }
}
