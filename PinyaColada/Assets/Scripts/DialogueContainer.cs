using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueContainer : MonoBehaviour
{
    public GameObject backPlayer, backNPC;
    public GameObject buttonAdvanceDialogue;
    public void PickBack(bool isPlayer) {
        if (isPlayer) {
            backPlayer.SetActive(true);
            backNPC.SetActive(false);
            buttonAdvanceDialogue.SetActive(false);
        } else {
            backPlayer.SetActive(false);
            backNPC.SetActive(true);
            buttonAdvanceDialogue.SetActive(true);
        }

    }
}
