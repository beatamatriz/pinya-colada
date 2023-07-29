using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownManager : MonoBehaviour {
    [Range(0, 1800)] public float time;
    public float timeSpeed;

    void Update()
    {
         time -= Time.deltaTime * timeSpeed;
    }
}
