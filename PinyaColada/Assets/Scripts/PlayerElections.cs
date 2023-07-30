using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerElections : MonoBehaviour {
    public static PlayerElections ins;

    [HideInInspector] public AudioManager aM;

    [Tooltip("Número que indica qué final hemos sacado.")] public int endIndex = 0;
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
            //Selección de finales
            switch (endIndex) {
                case 1:
                    EndingSceneScript.ins.BadActivate();
                    break;
                case 2:
                    EndingSceneScript.ins.GoodActivate();
                    break;
                default:
                    break;
            }
        }
    }
}