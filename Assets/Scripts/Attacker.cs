using UnityEngine;

public class Attacker : MonoBehaviour
{
    float movementSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
}
