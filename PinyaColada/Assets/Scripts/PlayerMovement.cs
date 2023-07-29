using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rB;

    void Start() {
        rB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rB.velocity = Vector2.right;
    }
}