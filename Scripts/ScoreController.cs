using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text _bestScore;
    [SerializeField]
    private Text _curScore;

    public static int CurScore;

    void OnEnable()
    {
        _bestScore.text = "Best Score: " + PlayerPrefs.GetInt("BestScore").ToString();
        CurScore = 0;
    }

    private void Update()
    {
        _curScore.text = CurScore.ToString();
    }
    void OnDisable()
    {
        if (CurScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", CurScore);
        }
        CurScore = 0;
    }


}
