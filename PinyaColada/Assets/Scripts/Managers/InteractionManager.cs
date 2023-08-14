using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {
    //Tiempo antes de que se pueda desactivar el texto manualmente.
    public float deactivationSafeTime;
    //Seguro de desactivación del texto.
    public bool deactivationSafe = true;
    private float deactivationSafeCounter;
    //Velocidad a la que se muestra el texto.
    public float txtSpeed;
    //Tiempo durante el que se mostrará el texto completo antes de desactivarse.
    public float txtLifetime;
    private float txtLifetimeCounter;

    private int txtIndex = 0;
    private string currentTxt;

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

    //Se llama desde el método del botón, con los datos pertinentes desde la llamada.
    public void DisplayText(string text, GameObject bgPanel, Text objTextbox) {
        BackToDefault();

        //Si el botón no está activo...
        if (!isActive) {
            //Se activa.
            isActive = true;
            currentTxt = text;

            //Si el valor pasado de alguna de estas variables no es nulo, se asigna al Manager.
            if (bgPanel != null) {
                this.bgPanel = bgPanel;
            } else {
                Debug.LogWarning("Usando panel de texto por defecto");
            }
            if (objTextbox != null) {
                this.objTextbox = objTextbox;
                Debug.LogWarning("Usando caja de texto por defecto");
            }

            //Se comienza a mostrar el texto.
            StartCoroutine(DisplayLetter(currentTxt));
        }
    }

    private void Update() {
        //Interacciones que puede tener el jugador con el texto.
        PlayerTxtInteraction();

        if (objTextbox.text == currentTxt) {
            TextCompletionCountdowns();
        }

        //Se comprueba si hay texto o no, si hay se muestra el fondo.
        if (objTextbox.text == "") {
            bgPanel.SetActive(false);
        } else {
            bgPanel.SetActive(true);
        }
    }

    private void PlayerTxtInteraction() {
        //Si está activo...
        if (isActive) {
            //...Se puede pasar el texto, está desactivado el seguro de desactivación y se pulsa el click izquierdo...
            if (skipTxt && !deactivationSafe && Input.GetMouseButtonDown(0)) {
                //Se llama al método de desactivación.
                DeactivateTxt();
                //Si no se cumple lo anterior y el texto no se puede pasar y se pulsa el click izquierdo...
            } else if (!skipTxt && Input.GetMouseButtonDown(0)) {
                //...Se puede pasar el texto.
                skipTxt = true;
            }
        }
    }

    void TextCompletionCountdowns() {
        if (currentTxt == objTextbox.text) {
            if (deactivationSafeCounter < 0) {
                deactivationSafe = false;
            } else {
                deactivationSafeCounter -= Time.deltaTime;
            }

            if (txtLifetimeCounter < 0) {
                DeactivateTxt();
            } else {
                txtLifetimeCounter -= Time.deltaTime;
            }
        }
    }

    IEnumerator DisplayLetter(string text) {
        //Se espera el tiempo que indique la velocidad del texto.
        yield return new WaitForSeconds(txtSpeed);

        //Si el texto de la caja es igual al texto objetivo o si se puede pasar el texto...
        if (objTextbox.text == text || skipTxt) {
            //Se iguala el texto de la caja al objetivo.
            objTextbox.text = text;
            //Se pasa el texto.
            skipTxt = true;

            yield return null;
        } else {
            objTextbox.text += text[txtIndex];
            txtIndex++;

            StartCoroutine(DisplayLetter(text));
        }
    }

    private void DeactivateTxt() {
        objTextbox.text = "";
        isActive = false;
        BackToDefault();
    }

    private void BackToDefault() {
        objTextbox = defaultObjTextbox;
        bgPanel = defaultBgPanel;

        deactivationSafeCounter = deactivationSafeTime;
        txtLifetimeCounter = txtLifetime;

        txtIndex = 0;
        deactivationSafe = true;
        endWriting = false;
        skipTxt = false;
    }

}