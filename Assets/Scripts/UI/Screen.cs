using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private Score _score;

    [SerializeField] private TMP_Text _scoreView;
    [SerializeField] private TMP_Text _TopScoreView;


    protected void ShowScore()
    {
        _scoreView.text = $"Score:{_score.ScoreValue}";
        _TopScoreView.text = $"Score:{PlayerPrefs.GetInt("TopScore")}";
    }
}