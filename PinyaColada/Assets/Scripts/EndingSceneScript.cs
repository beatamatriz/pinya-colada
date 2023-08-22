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

        if (PlayerElections.instance && PlayerElections.instance.goodEnding) {
            badEnd.SetActive(false);
            GoodActivate();
            AudioManager.ins.Play(3);
        } else {
            goodEnd.SetActive(false);
            BadActivate();
            AudioManager.ins.Play(2);
        }
    }

    #region Activaci�n de finales
    public void BadActivate()
    {
        badEnd.SetActive(true);
    }
    public void GoodActivate()
    {
        goodEnd.SetActive(true);
    }
    #endregion

    public void ActivateCredits() {
        credits.SetActive(true);
    }

    public void Retry() {
        // SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
