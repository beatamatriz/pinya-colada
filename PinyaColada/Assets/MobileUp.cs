using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MobileUp : MonoBehaviour
{
    public Sprite mobileAgenda, mobileCalling, mobileMum;
    public DialogueCreator dialogueCreator;
    public Image mobileUp;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void CallMum()
    {
        Call(Contacts.mum);
    }
    public void Call(Contacts contactToCall)
    {
        if (contactToCall == Contacts.mum)
        {
            mobileUp.sprite = mobileCalling;
            ShowUpContactTalking(mobileMum);
        }
    }
    public void ShowUpContactTalking(Sprite contactToShow)
    {
        mobileUp.sprite = contactToShow;
        dialogueCreator.StartDialogue();
    }
}
public enum Contacts
{
    mum, friend
}
