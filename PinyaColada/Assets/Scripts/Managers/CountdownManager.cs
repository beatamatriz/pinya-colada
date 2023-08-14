using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour {
    [Header("Time Variables")]
    [Range(0, 1800)] [Tooltip("Avaliable time")] public float time;
    private float iniTime;

    public float timeSpeed = 1;
    public float timeFastSpeed = 1;
    public bool isGameStarted = false;

    [Space]

    public GameObject meteorite;
    public float meteoriteSpeed = 1;
    public Transform meteoriteObjective;
    public Image colorChangeObject;

    public Gradient BGColorTransition;

    private void Start() {
        iniTime = time;
    }

    void Update() {
        if (isGameStarted) {
            if (timeSpeed < 0) {
                Debug.LogWarning("¡La velocidad del tiempo es negativa!");
            }

            if (time <= 0) {
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            }

            time -= Time.deltaTime * timeSpeed;

            MeteoriteFall();
            AlphaChange();
            SkyChange();
        }
    }

    void AlphaChange() {
        colorChangeObject.color = new Color(colorChangeObject.color.r, colorChangeObject.color.g, colorChangeObject.color.b, (time - Time.deltaTime) / time * 100);
    }

    void SkyChange() {
        float BGColorPos = (time - Time.deltaTime) / time * 100;
        Camera.main.backgroundColor = BGColorTransition.Evaluate(BGColorPos);
    }

    void MeteoriteFall() {
        meteorite.transform.position = Vector3.Lerp(meteorite.transform.position, meteoriteObjective.position, meteoriteSpeed/iniTime * Time.deltaTime);
    }

    public void UpdateTimeSpeed() {
        timeSpeed = timeFastSpeed;
    }
}