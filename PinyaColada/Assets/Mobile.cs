using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mobile : MonoBehaviour
{
    public UnityEngine.UI.Image mobile;
    public Sprite colouredMobile, blackAndWhite;
    public Button mobileButton;
    public float timeToMakePhoneInteractable=4;
    public GameObject mobileUI;
    void Start(){
        mobile.sprite=blackAndWhite;
        mobileButton.enabled=false;
        Invoke(nameof(MakePhoneInteractable),timeToMakePhoneInteractable);
    }
    // Start is called before the first frame update
   public void MakePhoneInteractable(){
GetComponent<UnityEngine.UI.Image>().sprite=colouredMobile;
mobileButton.enabled=true;
   }
   public void InteractWithMobile(){
    print("Interacting with mobileUI");
    mobileUI.SetActive(true);
   }
}
