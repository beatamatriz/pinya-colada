using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rB;

    void Start() {
        rB = GetComponent<Rigidbody2D>();
    }

    void Update() {
        //if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < -10) {
        //    rB.velocity = Vector2.right;
        //}
    }
}