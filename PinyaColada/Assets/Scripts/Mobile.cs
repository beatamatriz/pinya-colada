using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mobile : MonoBehaviour
{
    public Image mobile;
    public Sprite colouredMobile, blackAndWhite;
    public Button mobileButton;
    public float timeToMakePhoneInteractable = 4;
    public GameObject mobileUI;
    public GameObject arrowContinue;
    
    void Start() {
        mobile.sprite = blackAndWhite;
        mobileButton.enabled = false;
        arrowContinue.SetActive(false);
    }

    public void PhoneSetup() {
        Invoke(nameof(MakePhoneInteractable), timeToMakePhoneInteractable);
    }

    public void MakePhoneInteractable() {
        GetComponent<Image>().sprite = colouredMobile;
        mobileButton.enabled = true;
    }

    public void PlayMobileSFX() {
        AudioManager.ins.Play(4);
    }

    public void InteractWithMobile() {
        print("Interacting with mobileUI");
        mobileUI.SetActive(true);
        arrowContinue.SetActive(true);
        gameObject.SetActive(false);
    }
}
