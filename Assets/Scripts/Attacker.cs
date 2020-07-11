using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 3f)] [SerializeField] float walkSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);
    }
}
