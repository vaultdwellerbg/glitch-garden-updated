﻿using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float movementSpeed = 1f;
    GameObject currentTarget;
    Animator animator;

	private void Awake()
	{
        FindObjectOfType<LevelController>().AttackerSpawned();
	}

	private void Start()
	{
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
        UpdateAnimationState();
    }

	private void OnDestroy()
	{
        var levelController = FindObjectOfType<LevelController>();
        if (levelController)
        {
            levelController.AttackerDestroyed();
        }
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

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) return;

        Health targetHealth = currentTarget.GetComponent<Health>();
        if (targetHealth)
        {
            targetHealth.DealDamage(damage);
        }
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
