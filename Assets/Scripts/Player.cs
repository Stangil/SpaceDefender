using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15.0f;
    [SerializeField] float projectileSpeed = 30.0f;

    [SerializeField] float playerLimitMax = 0.95f;
    [SerializeField] float playerLimitMin = 0.05f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserOffset = 0.8f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        Move();
        Fire();
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }
    }

    private void Move()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(playerLimitMin, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(playerLimitMax, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, playerLimitMin, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, playerLimitMax, 0)).y;
    }
}
