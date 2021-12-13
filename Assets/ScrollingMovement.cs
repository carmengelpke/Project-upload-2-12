using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class ScrollingMovement : MonoBehaviour
{
    public float speed;
    private Vector2 newPosition;
    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        newPosition.x = transform.position.x;
        newPosition.y = 14.6f;

        if (transform.position.y < -14.77f)
        {
            transform.position = newPosition;
        }
    }
}
