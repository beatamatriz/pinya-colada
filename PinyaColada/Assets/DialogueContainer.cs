using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueContainer : MonoBehaviour
{
    public GameObject backPlayer, backNPC;
    public void PickBack(bool isPlayer) {
        if (isPlayer) {
            backPlayer.SetActive(true);
            backNPC.SetActive(false);
        } else {
            backPlayer.SetActive(false);
            backNPC.SetActive(true);
        }
    }
}
