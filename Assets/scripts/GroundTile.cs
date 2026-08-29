using System;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float groundWidth = 20f;
    private void Update()
    {
        if(GameManager.Instance.isGameOver)
            return;


        if (transform.position.x +  groundWidth / 2f < Player.position.x)
        {
            transform.position += Vector3.right * (groundWidth * 2f);
        }
    }   
}
