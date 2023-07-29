using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueContainer : MonoBehaviour
{
    public Sprite backPlayer, backNPC;
    public Image backImage;
    public void PickBack(bool isPlayer)
    {
        if (isPlayer)
        {
            backImage.sprite = backPlayer;
        }
        else
        {
            backImage.sprite = backNPC;
        }
    }
}
