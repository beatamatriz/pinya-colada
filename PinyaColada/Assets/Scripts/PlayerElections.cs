using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerElections : MonoBehaviour {
    public static PlayerElections instance;
    [HideInInspector] public AudioManager aM;
    [Tooltip("N�mero que indica qu� final hemos sacado.")] public bool goodEnding = false;
    public Scene endScene;
    private void Awake() {
        DontDestroyOnLoad(gameObject);
        
        if (instance == null) {
            instance = this;
        }

        if (SceneManager.GetActiveScene().buildIndex == 0) {
            SceneManager.LoadScene(1);
        }

        aM = GetComponent<AudioManager>();
    }
    public void Win() {
        goodEnding = true;
    }
}