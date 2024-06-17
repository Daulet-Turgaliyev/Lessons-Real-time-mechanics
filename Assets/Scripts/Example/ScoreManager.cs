using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private int _score = 0;

    private void Awake()
    {
        Instance = this;
    }
    
    public void AddPoints(int points)
    {
        _score += points;
        _scoreText.text = _score.ToString();
    }
}
