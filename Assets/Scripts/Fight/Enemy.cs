using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float _speed = 1.5f;

    private Rigidbody2D physic;
    private Animator animator;
    [SerializeField] private float agroDistance;
    private int health = 10;

    private void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroDistance)
        {
            StartHunting();
        } 
        else
        {
            StopHunting();
        }
    }
    public void TakeDamage(int damage)
    {
        health--;
        CheckHealth();
    }
    private void CheckHealth()
    {
        if (health == 0)
            gameObject.SetActive(false);
    }

    private void StartHunting()
    {
        if(player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-_speed, 0);
        } 
        else if(player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(_speed, 0);
        }
    }
    private void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }
}
