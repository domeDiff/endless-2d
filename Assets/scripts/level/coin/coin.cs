using Unity.VisualScripting;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private float destroyDistance = 15f;
    [SerializeField] private AudioClip collectSfx; // assign in Inspector

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * GameManager.Instance.WorldSpeed * Time.deltaTime);

        if (transform.position.x < player.position.x - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        CoinManager.Instance.AddCoins(coinValue);

        if (collectSfx != null)
            AudioSource.PlayClipAtPoint(collectSfx, transform.position);
            

        Destroy(gameObject);
    }
}