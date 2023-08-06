using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRefs : MonoBehaviour {
    [HideInInspector] public static ManagerRefs instance;
    [HideInInspector] public CountdownManager cM;
    [HideInInspector] public GameManager gM;
    [HideInInspector] public AudioManager aM;
    [HideInInspector] public InteractablesManager iM;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        cM = GetComponent<CountdownManager>();
        gM = GetComponent<GameManager>();
        aM = GetComponent<AudioManager>();
        iM = GetComponent<InteractablesManager>();
    }
}