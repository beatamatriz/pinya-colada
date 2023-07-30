using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    [TextArea] public string objText;
    int objTextIndex;
    public float deactivationSafe;

    public float txtSpeed;
    private float counter;

    public GameObject bGPanel;
    public float txtLifetime;
    public bool endWritingFirst = false;

    bool isActive = false;

    public void CallInteraction() {
        if (!isActive) {
            ManagerRefs.instance.gM.objTextbox.text = "";
            counter = txtSpeed;
            objTextIndex = 0;

            isActive = true;
        }
    }

    private void Update() {
        if (isActive && ManagerRefs.instance.gM.objTextbox.text != objText) {
            //Completar texto poco a poco.
            counter -= Time.deltaTime;

            if (counter <= 0) {
                ManagerRefs.instance.gM.objTextbox.text += objText[objTextIndex];
                objTextIndex++;

                counter = txtSpeed;
            }

            if (Input.GetMouseButtonDown(0)) {
                ManagerRefs.instance.gM.objTextbox.text = objText;
            }

        } else if (isActive && ManagerRefs.instance.gM.objTextbox.text == objText) {
            if (!endWritingFirst) {
                endWritingFirst = true;
            }

            if (Input.GetMouseButtonDown(0)) {
                StartCoroutine(DeactivateWait());
            }
        }

        if (ManagerRefs.instance.gM.objTextbox.text == "") {
            bGPanel.SetActive(false);
        } else {
            bGPanel.SetActive(true);
        }
    }

    IEnumerator DeactivateWait() {
        yield return new WaitForSeconds(deactivationSafe);

        ManagerRefs.instance.gM.objTextbox.text = "";

        isActive = false;
    }

    IEnumerator TextLife() {
        yield return new WaitForSeconds(txtLifetime);

        ManagerRefs.instance.gM.objTextbox.text = "";
    }
}