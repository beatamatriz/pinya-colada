using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneScript : MonoBehaviour {

    public static EndingSceneScript ins;

    public GameObject badEnd;
    public GameObject goodEnd;

    public GameObject credits;

    private void Awake() {
        if (ins == null) {
            ins = this;
        }

        if (PlayerElections.ins.goodEnding) {
            GoodActivate();
        } else {
            BadActivate();
        }
    }

    #region Activación de finales
    public void BadActivate() {
        badEnd.SetActive(true);
    }

    public void GoodActivate() {
        goodEnd.SetActive(true);
    }
    #endregion

    public void ActivateCredits() {
        credits.SetActive(true);
    }

    public void Retry() {
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
