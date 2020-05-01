using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15.0f;
    void Start()
    {
        
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        var newXPos = transform.position.x + deltaX;
        transform.position = new Vector2(newXPos, newYPos);
    }
}
