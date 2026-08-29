using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed = 0.5f; // Adjust this value to control the parallax effect
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameOver)
            return;

        transform.position += Vector3.left * parallaxSpeed * Time.deltaTime;
    }
}
