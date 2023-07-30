using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerElections : MonoBehaviour {
    public static PlayerElections ins;

    [HideInInspector] public AudioManager aM;

    [Tooltip("N�mero que indica qu� final hemos sacado.")] public int endIndex;
    public Scene endScene;
    
    private void Awake() {
        DontDestroyOnLoad(gameObject);

        if (ins == null) {
            ins = this;
        }

        aM = GetComponent<AudioManager>();
    }

    private void OnLevelWasLoaded(int level) {
        if (level == endScene.buildIndex) {
            //Selecci�n de finales
            switch (endIndex) {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}