using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rB;

    [Tooltip("The minimum X value for the screen to start scrolling left")]
    public float minLeft;
    [Tooltip("The minimum X value for the screen to start scrolling right")]
    public float minRight;
    [Tooltip("The maximum X value the object can scroll to by the left")]
    public float limitLeft;
    [Tooltip("The maximum X value the object can scroll to by the right")]
    public float limitRight;

    public float speedMultiplier;

    void Start() {
        rB = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float objX = transform.position.x;

        if (mouseX < minLeft) {
            if (objX > limitLeft) {
                rB.velocity = Vector2.zero;
                Debug.Log("reached screen limits");
                return;
            }
            // might not work if minLeft is negative
            rB.velocity = Vector2.right * -speedMultiplier * (mouseX - minLeft) / minLeft;
            Debug.Log("scrolling left");
            return;
        }

        if (mouseX > minRight) {
            if (objX < limitRight) {
                rB.velocity = Vector2.zero;
                Debug.Log("reached screen limits");
                return;
            }
            rB.velocity = Vector2.left * speedMultiplier * (mouseX - minRight) / minRight;
            Debug.Log("scrolling right");
            return;
        }

        rB.velocity = Vector2.zero;
    }
}
