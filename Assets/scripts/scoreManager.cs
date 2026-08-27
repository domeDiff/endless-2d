using UnityEngine;

public class scoreManager : MonoBehaviour
{
    private float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        Debug.Log("Score: " + Mathf.FloorToInt(score));

    }
}
