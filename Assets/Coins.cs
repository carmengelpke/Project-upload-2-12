using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random=UnityEngine.Random;

public class Coins : MonoBehaviour
{
    private Vector2 newPos;
    public List<float> possiblePosition;

    private void Update()
    {
        transform.Translate(Vector2.down * Home.speed * Time.deltaTime);
        int rand = Random.Range(0, possiblePosition.Count);
        newPos.x = possiblePosition.ElementAt(rand);
        newPos.y = 6f;
        if (transform.position.y <= -3f)
        {
            transform.position = newPos;
        }
    }
}

