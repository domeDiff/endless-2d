using Unity.VisualScripting;
using UnityEngine;

public class CatIdle : MonoBehaviour
{
    [SerializeField] private float floatHeight = 0.15f;
    [SerializeField] private float floatSpeed = 2f;

    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            float y = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            transform.position = startPos + Vector3.up * y;
    }
}
