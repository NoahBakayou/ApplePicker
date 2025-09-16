using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour {
    static private TextMeshProUGUI _UI_TEXT;
    static private int _SCORE = 1000;

    void Awake() {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();
        if (_UI_TEXT == null) {
            Debug.LogError("TextMeshProUGUI not found on HighScore GameObject.");
        }
        _UI_TEXT.text = "High Score: " + _SCORE.ToString("#,0");
    }

    static public int SCORE {
        get { return _SCORE; }
        private set {
            _SCORE = value;
            if (_UI_TEXT != null) {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry) {
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }
}