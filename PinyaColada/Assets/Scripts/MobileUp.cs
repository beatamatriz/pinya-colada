using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MobileUp : MonoBehaviour
{
    public Sprite mobileAgenda, mobileCalling, mobileMum;
    public DialogueCreator dialogueCreator;
    public DialogueContainer dialogueContainer;
    public Image mobileUp;
    public GameObject buttonAdvanceDialogue;
    public float timeCalling = 2;
    public Mobile mobile;
    bool canEndialog = false;
    private void Start()
    {
        gameObject.SetActive(false);
        //para la ui
        // UnityEngine.SceneManagement.SceneManager.LoadScene("", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
    public void CallMum()
    {
        Call(Contacts.mum);
    }
    public void Call(Contacts contactToCall)
    {
        mobileUp.sprite = mobileCalling;
        if (contactToCall == Contacts.mum)
        {
            Invoke(nameof(ShowMumOnMobile), timeCalling);
        }
    }
    private void ShowMumOnMobile()
    {
        mobileUp.sprite = mobileCalling;
        ShowUpContactTalking(mobileMum);
    }
    public void ShowUpContactTalking(Sprite contactToShow)
    {
        mobileUp.sprite = contactToShow;
        dialogueCreator.StartDialogue();
        buttonAdvanceDialogue.SetActive(true);
    }
    public void EndDialogue()
    {
        if (canEndialog)
        {
            mobile.gameObject.SetActive(true);
            mobileUp.sprite = mobileAgenda;
            buttonAdvanceDialogue.SetActive(false);
            print("ending dialogue");
            mobile.arrowContinue.SetActive(false);
            dialogueContainer.backNPC.SetActive(false);
            dialogueContainer.backPlayer.SetActive(false);

            gameObject.SetActive(false);
        }
        canEndialog = true;
    }
}
public enum Contacts
{
    mum, friend
}
