using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractablesManager : MonoBehaviour {

    int objTextIndex;
    public float deactivationSafe;
    public float txtSpeed;
    public float txtLifetime;
    public Text objTextbox;

    public bool endWriting = false;
    //Está activo el texto.
    public bool isActive = false;

    public void DisplayText(string text, GameObject bgPanel) {
        if (!isActive) {
            objTextIndex = 0;


            StartCoroutine(DisplayLetter(text));
        }

        //if (isActive && objTextbox.text != text) {
        //    //Completar texto poco a poco.
        //    counter -= Time.deltaTime;
        //    if (counter <= 0) {
        //        if (objTextIndex < text.Length) {
        //            objTextbox.text += text[objTextIndex];
        //            objTextIndex++;
        //        }
        //        counter = txtSpeed;
        //    }
        //    if (Input.GetMouseButtonDown(0)) {
        //        objTextbox.text = text;
        //    }
        //} else if (isActive && objTextbox.text == text) {
        //    if (!endWriting) {
        //        endWriting = true;
        //    }
        //    if (Input.GetMouseButtonDown(0)) {
        //        StartCoroutine(DeactivateWait());
        //    }
        //}

        if (objTextbox.text == "") {
            bgPanel.SetActive(false);
        } else {
            bgPanel.SetActive(true);
        }
    }

    IEnumerator DisplayLetter(string text) {
        yield return new WaitForSeconds(txtSpeed);
        foreach (char letter in text) {
            if (objTextbox.text != text) {
                objTextbox.text += letter;

                StartCoroutine(DisplayLetter(text));
            } else if (objTextbox.text == text ||) {
                objTextbox.text = text;

                yield return null;
            }
        }
    }

    IEnumerator DeactivateWait() {
        yield return new WaitForSeconds(deactivationSafe);
        objTextbox.text = "";
        isActive = false;
    }

    IEnumerator TextLife() {
        yield return new WaitForSeconds(txtLifetime);
        objTextbox.text = "";
    }
}