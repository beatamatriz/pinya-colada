using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {
    //Tiempo antes de que se pueda desactivar el texto manualmente.
    public float deactivationSafeTime;
    //Seguro de desactivación del texto.
    public bool deactivationSafe = true;
    //Velocidad a la que se muestra el texto.
    public float txtSpeed;
    //Tiempo durante el que se mostrará el texto completo antes de desactivarse.
    public float txtLifetime;
    
    //Textbox
    private Text objTextbox;
    public Text defaultObjTextbox;
    
    //Panel del texto
    private GameObject bgPanel;
    public GameObject defaultBgPanel; 

    //Se quiere completar el texto.
    public bool endWriting = false;
    //Está activo el texto.
    public bool isActive = false;
    //Se quiere pasar el texto.
    public bool skipTxt = false;

    private void Start() {
        BackToDefault();
    }

    public void DisplayText(string text, GameObject bgPanel, Text objTextbox) {
        if (!isActive) {
            isActive = true;

            if (bgPanel != null) {
                this.bgPanel = bgPanel;
            } else {
                Debug.LogWarning("Usando panel de texto por defecto");
            }

            if (objTextbox != null) {
                this.objTextbox = objTextbox;
                Debug.LogWarning("Usando caja de texto por defecto");
            }
            
            StartCoroutine(DisplayLetter(text));
        }
    }

    private void Update() {
        PlayerTxtInteraction();

        if (objTextbox.text == "") {
            bgPanel.SetActive(false);
        } else {
            bgPanel.SetActive(true);
        }
    }
    
    IEnumerator DisplayLetter(string text) {

        yield return new WaitForSeconds(txtSpeed);

        foreach (char letter in text) {
            if (objTextbox.text == text || skipTxt) {
                objTextbox.text = text;
                skipTxt = true;

                StartCoroutine(DeactivateWait());
                StartCoroutine(TextLife());

                yield return null;
            } else {
                objTextbox.text += letter;

                StartCoroutine(DisplayLetter(text));
            }
        }
    }

    private void DeactivateTxt() {
        BackToDefault();
        objTextbox.text = "";
        isActive = false;
    }

    private void BackToDefault() {
        objTextbox = defaultObjTextbox;
        bgPanel = defaultBgPanel;

        deactivationSafe = true;
        endWriting = false;
        skipTxt = false;
    }

    private void PlayerTxtInteraction() {
        if (skipTxt && deactivationSafe && Input.GetMouseButtonDown(0)) {
            DeactivateTxt();
        } else if (isActive && !skipTxt && Input.GetMouseButtonDown(0)) {
            skipTxt = true;
        } 
    }

    IEnumerator DeactivateWait() {
        yield return new WaitForSeconds(deactivationSafeTime);
        deactivationSafe = false;
    }

    IEnumerator TextLife() {
        yield return new WaitForSeconds(txtLifetime);
        DeactivateTxt();
    }
}