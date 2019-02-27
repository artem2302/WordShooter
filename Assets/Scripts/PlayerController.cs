﻿
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSpeed = 3f;

    private PlayerMotor motor;

    void Start() {
        Cursor.visible = false;
        motor = GetComponent <PlayerMotor> ();
    }

    void Update() {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        
        Vector3 moveHor = transform.right * xMove;
        Vector3 moveVer = transform.forward * zMove;

        Vector3 velocity = (moveHor + moveVer).normalized * speed;

        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSpeed;

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0f, 0f) * lookSpeed;

        motor.RotateCam(camRotation);
    }
}
