using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public static int scoreValue = 0;
    Text score;
    public int level,scorenextlv;
    public GameObject panelnextlv;
    public Text tlevel;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
        scoreValue = 0;
        score = GetComponent<Text>();
        InvokeRepeating("checkwin", 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
        tlevel.text = "Level " + level;
    }


    void checkwin() {
        if (scoreValue >= scorenextlv) {
            panelnextlv.SetActive(true);
            GameObject[] emy = GameObject.FindGameObjectsWithTag("Police");

            for (int i = 0; i < emy.Length; i++) {
                Destroy(emy[i]);
            }
            Time.timeScale = 0;
        }
    }

    public void cliknextlv() {
        scoreValue = 0;
        level++;
        panelnextlv.SetActive(false);
        Time.timeScale = 1;
    }
}
