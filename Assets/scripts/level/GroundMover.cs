using Unity.VisualScripting;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;

        MoveGround();
    }

    private void MoveGround()
    {
        transform.Translate(Vector3.left * GameManager.Instance.WorldSpeed * Time.deltaTime);
    }

}
