using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text objTextbox;
    public GameObject safePanel;

    public GameObject mainScreen;
    public float startGameCounter = 2;
    public float MainScreenSafeTime = 1;
    public Mobile mobileSmall;

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

    public void EndSelection(int endIndex) {
        PlayerElections.instance.endIndex = endIndex;
    }

    IEnumerator MainScreenSafe() {
        yield return new WaitForSeconds(MainScreenSafeTime);

        mainScreen.SetActive(false);
    }
}