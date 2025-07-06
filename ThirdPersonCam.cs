using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ThirdPersonCam : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float rotationSpeedSlider;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player body
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //if inputDir != Vector3.zero
        if (inputDir != Vector3.zero)
        {
            playerBody.forward = Vector3.Slerp(playerBody.forward, inputDir.normalized, Time.deltaTime * rotationSpeedSlider);
        }
    }
}
