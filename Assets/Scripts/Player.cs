using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15.0f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    [SerializeField] float playerLimitMax = 0.95f;
    [SerializeField] float playerLimitMin = 0.05f;
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(playerLimitMin, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(playerLimitMax, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, playerLimitMin, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, playerLimitMax, 0)).y;
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
}
