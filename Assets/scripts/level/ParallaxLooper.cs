using UnityEngine;

public class ParallaxLooper : MonoBehaviour
{
    [SerializeField] private Transform[] backgrounds;
    [SerializeField] private float backgroundWidth = 20f;
   
    void Update()
    {
        if(GameManager.Instance.isGameOver) 
            return;    
        foreach(Transform back in backgrounds)
        {
            if(back.position.x < Camera.main.transform.position.x - backgroundWidth)
            {
                back.position += Vector3.right * backgroundWidth * 2f;
            }
        }
    }
}
