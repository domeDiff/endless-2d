using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameOver)
            return;

        float worldSpeed = GameManager.Instance.WorldSpeed;

        float moveSpeed = worldSpeed * parallaxMultiplier;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
