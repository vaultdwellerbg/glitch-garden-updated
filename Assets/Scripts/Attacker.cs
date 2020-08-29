using UnityEngine;

public class Attacker : MonoBehaviour
{
    float movementSpeed = 1f;
    GameObject currentTarget;
    Animator animator;

	private void Start()
	{
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }
}
