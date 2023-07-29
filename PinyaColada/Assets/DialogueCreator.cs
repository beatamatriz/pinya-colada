using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
public class DialogueCreator : MonoBehaviour
{
   public DialogueManager dialogueManager;
   public VIDE_Assign videAssign;
public void StartDialogue(){
    dialogueManager.Interact(videAssign);
}
}
