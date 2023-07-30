using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerElections : MonoBehaviour {
    public static PlayerElections instance;

    [Tooltip("N�mero que indica qu� final hemos sacado.")] public int endIndex;
    public Scene endScene;
    
    private void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        }
    }

    private void OnLevelWasLoaded(int level) {
        if (level == endScene.buildIndex) {

        }
    }
}