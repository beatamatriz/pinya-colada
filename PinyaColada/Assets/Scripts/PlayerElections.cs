using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerElections : MonoBehaviour {
    public static PlayerElections ins;

    [HideInInspector] public AudioManager aM;

    [Tooltip("Número que indica qué final hemos sacado.")] public bool goodEnding = false;
    public Scene endScene;

    private void Awake() {
        DontDestroyOnLoad(gameObject);

        if (ins == null) {
            ins = this;
        }

        aM = GetComponent<AudioManager>();
    }

    public void Win() {
        goodEnding = true;
    }
}