using Unity.VisualScripting;
using UnityEngine;

public class bird : MonoBehaviour
{
    [SerializeField] private float destroyDistance = 15f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (transform.position.x < player.position.x - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
