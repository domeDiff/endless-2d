using Unity.VisualScripting;
using UnityEngine;


//used for squatch & stretching the player sprite when jumping
public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private float jumpScaleY = 1.1f;
    [SerializeField] private float jumpScaleX = 0.95f;

    [SerializeField] private float landScaleY = 0.8f;
    [SerializeField] private float landScaleX = 1.1f;

    [SerializeField] private float scaleSpeed = 10f;
    private Vector3 normalScale;
    private PlayerController playerController;

    private void Awake()
    {
        normalScale = transform.localScale;
        playerController = GetComponentInParent<PlayerController>();
    }
    void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;


        bool isJumping = !playerController.IsGrounded;

        Vector3 targetScale = normalScale;

        if (playerController.JustLanded)
        {
            targetScale = new Vector3(normalScale.x * landScaleX, normalScale.y * landScaleY, normalScale.z);
        }

        else if (isJumping)
        {
            targetScale = new Vector3(normalScale.x * jumpScaleX, normalScale.y * jumpScaleY, normalScale.z);
        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
    }
}
