using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : MonoBehaviour
{
    public float moveSpeed = 1f;

    public void Enable()
    {
        //Debug.Log("ShipAI Enable");
        moveSpeed *= Random.Range(0f, 1f) >= 0.5f ? 1f : -1f;
        Debug.Log("Ship movement is: " + moveSpeed);
    }

    void Update()
    {

    }
}
