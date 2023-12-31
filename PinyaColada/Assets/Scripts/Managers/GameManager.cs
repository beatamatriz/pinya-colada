using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject safePanel;

    public GameObject mainScreen;
    public float startGameCounter = 2;
    public float MainScreenSafeTime = 1;
    public Mobile mobileSmall;

    //private void Start() {
    //    PlayerElections.instance.aM.Play(0);
    //}

    private void Update() {
        if (mainScreen.activeInHierarchy) {
            if (startGameCounter > 0) {
                startGameCounter -= Time.deltaTime;
            }

            if (Input.GetMouseButtonDown(0) && startGameCounter <= 0) {
                mainScreen.GetComponent<Animator>().SetTrigger("Start");
                ManagerRefs.instance.cM.isGameStarted = true;
                mobileSmall.PhoneSetup();
                StartCoroutine(MainScreenSafe());
            }
        }
    }

    IEnumerator MainScreenSafe() {
        yield return new WaitForSeconds(MainScreenSafeTime);

        mainScreen.SetActive(false);
    }

    public void CallWin() {
        PlayerElections.instance.goodEnding = true;
    }
}