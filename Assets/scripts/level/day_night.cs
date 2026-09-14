using System.Globalization;
using UnityEngine;

public class day_night : MonoBehaviour
{
    private float dayNightTimer = 0f;
    private Animator animator;
    private Camera mainCamera;

    private void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }
    void Update()
    {
        dayNightTimer += Time.deltaTime;

        animator.SetBool("isNight", true);
    }
}
