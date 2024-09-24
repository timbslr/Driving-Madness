using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    private float movementSpeed = -1.1f;

    void Update()
    {
        transform.Translate(new Vector3(0, movementSpeed * Time.deltaTime, 0));
    }

}
