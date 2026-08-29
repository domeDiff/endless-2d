using Unity.VisualScripting;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;

        MoveGround();
    }

    private void MoveGround()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

}
