using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour {
    [Header("Time Variables")]
    [Range(0, 1800)] [Tooltip("Avaliable time")] public float time;
    
    public float timeSpeed = 1;
    public float timeFastSpeed = 1;
    public bool isGameStarted = false;

    public GameObject meteorite;
    public Transform meteoriteObjective;
    public Image orangeRoom;
    public float orangeRoomLifetimeSpeed;
    


    void Update() {
        if (isGameStarted) {
            if (timeSpeed < 0) {
                Debug.LogWarning("¡La velocidad del tiempo es negativa!");
            }

            time -= Time.deltaTime * timeSpeed;

            MeteoriteFall();
            AlphaChange();
        }
    }

    void AlphaChange() {
        orangeRoom.color = new Color(orangeRoom.color.r, orangeRoom.color.g, orangeRoom.color.b, orangeRoom.color.a - Time.deltaTime * orangeRoomLifetimeSpeed);
    }

    void MeteoriteFall() {
        meteorite.transform.position = Vector3.MoveTowards(meteorite.transform.position, meteoriteObjective.position, timeSpeed * Time.deltaTime);
    }

    public void UpdateTimeSpeed() {
        timeSpeed = timeFastSpeed;
    }
}