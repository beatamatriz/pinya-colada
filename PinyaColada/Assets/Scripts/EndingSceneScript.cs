using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSceneScript : MonoBehaviour {

    public static EndingSceneScript ins;

    public GameObject neutralEnd;
    public GameObject badEnd;
    public GameObject goodEnd;

    private void Awake() {
        if (ins == null) {
            ins = this;
        }
    }

    #region Activación de finales
    public void NeutralActivate() {
        neutralEnd.SetActive(true);
    }

    public void BadActivate() {
        badEnd.SetActive(true);
    }

    public void GoodActivate() {
        goodEnd.SetActive(true);
    }
    #endregion

    public void ActivateCredits() {

    }

    public void Retry() {

    }

    public void ExitGame() {

    }
}
