using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownManager : MonoBehaviour {
    [Header("Time Variables")]
    [Range(0, 1800)] [Tooltip("Avaliable time")] public float time;
    
    public float timeSpeed = 1;
    public float timeFastSpeed = 1;

    void Update() {
        if (timeSpeed < 0) {
            Debug.LogWarning("¡La velocidad del tiempo es negativa!");
        }
        
         time -= Time.deltaTime * timeSpeed;
    }

    public void UpdateTimeSpeed() {
        timeSpeed = timeFastSpeed;
    }
}