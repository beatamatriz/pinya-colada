using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRefs : MonoBehaviour {
    [HideInInspector] public static ManagerRefs instance;
    [HideInInspector] public CountdownManager cM;
    [HideInInspector] public EndingManager eM;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        cM = GetComponent<CountdownManager>();
        eM = GetComponent<EndingManager>();
    }
}