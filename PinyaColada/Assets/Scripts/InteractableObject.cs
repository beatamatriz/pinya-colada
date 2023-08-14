using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour {
    [TextArea] public string objText;

    
    public GameObject bGPanel;
    public Text objTextbox;
    public float txtLifetime;
    public bool endWritingFirst = false;
    
    public void CallInteraction() {
        //Se llama al método de iniciar texto del InteractionManager, y se le devuelven las referencias pertinentes.
        ManagerRefs.instance.iM.DisplayText(objText, bGPanel, objTextbox);
    }
}