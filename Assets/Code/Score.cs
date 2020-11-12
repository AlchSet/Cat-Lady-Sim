using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {


    Text text;
    public int score;
    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
        text.text = "0";
        NPC.OnHitNPC = UpdateScore;
    }

    // Update is called once per frame
    void Update() {

    }


    public void UpdateScore(int value)
    {
        score += value;
        text.text = "" + score;
    }
}
