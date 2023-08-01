using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EmotionsNPC : MonoBehaviour
{
    public UnityEngine.UI.Image imageNPC;
    public Sprite normal, angry, happy, sad, extremelyHappy;
    public void GetNormal()
    {
        imageNPC.sprite = normal;
    }
    public void GetAngry()
    {
        imageNPC.sprite = angry;
    }
    public void GetHappy()
    {
        imageNPC.sprite = happy;
    }
    public void GetSad()
    {
        imageNPC.sprite = sad;
    }
    public void GetExtremelyHappy()
    {
        imageNPC.sprite = extremelyHappy;
    }
}
