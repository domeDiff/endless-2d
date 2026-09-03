using Unity.VisualScripting;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;

    private void Update()
    {
        transform.Translate(Vector3.left * GameManager.Instance.WorldSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        CoinManager.Instance.AddCoins(coinValue);

        Destroy(gameObject);
    }
}
