using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float rotation = 5f;
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, rotation * Time.deltaTime);
    }
}
