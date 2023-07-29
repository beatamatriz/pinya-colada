using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownManager : MonoBehaviour {
    [Range(0, 1800)] public float time;
    public float timeSpeed = 1;
    public float timeFastSpeed = 1;

    void Update()
    {
         time -= Time.deltaTime * timeSpeed;
    }

    public void UpdateTimeSpeed() {
        timeSpeed = timeFastSpeed;
    }
}