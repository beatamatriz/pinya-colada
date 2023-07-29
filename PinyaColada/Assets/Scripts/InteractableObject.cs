using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    [TextArea] public string objText;
    int objTextIndex;
    public float deactivationSafe;

    public float txtSpeed;
    private float counter;

    bool isActive = false;

    public void CallInteraction() {
        if (!isActive) {
            ManagerRefs.instance.gM.objTextbox.text = "";
            ManagerRefs.instance.gM.interactionPanel.SetActive(true);
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
            if (Input.GetMouseButtonDown(0)) {
                ManagerRefs.instance.gM.interactionPanel.SetActive(false);

                StartCoroutine(DeactivateWait());
            }
        }
    }

    IEnumerator DeactivateWait() {
        yield return new WaitForSeconds(deactivationSafe);

        isActive = false;
    }
}