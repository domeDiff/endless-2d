using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float destroyDistance = 15f;

    [SerializeField] private GameObject runEffect;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

        if (GameManager.Instance.isGameOver)
            return;


        transform.position += Vector3.left * GameManager.Instance.WorldSpeed * Time.deltaTime;

        if (transform.position.x < player.position.x - destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}