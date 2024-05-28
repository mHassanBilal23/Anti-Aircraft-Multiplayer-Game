using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private Camera cam;
    private Vector2 mousepos;
    public static float rotationSpeed = 60f;

    void Start()
    {
        // Only assign the camera to the local player
        if (photonView.IsMine)
        {
            cam = Camera.main;
        }
    }

    void Update()
    {
        // Only process input for the local player
        if (photonView.IsMine)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Ensure cam is not null before using it
            if (cam != null)
            {
                mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    void FixedUpdate()
    {
        // Only move and rotate the local player
        if (photonView.IsMine)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            // Ensure mouse position is calculated correctly
            if (cam != null)
            {
                Vector2 lookDir = mousepos - rb.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
