using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    [TextArea] public string objText;

    
    public GameObject bGPanel;
    public float txtLifetime;
    public bool endWritingFirst = false;
    

    public void CallInteraction() {
        ManagerRefs.instance.iM.DisplayText(objText, bGPanel);
    }
}