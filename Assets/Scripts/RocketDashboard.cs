using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class RocketDashboard : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject rocket;

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private float score;
    private float bestScore;

    private void Update()
    {
        score = (ground.transform.position - rocket.transform.position).magnitude;
        currentScoreText.text = $"{score.ToString("N0")}M";

        if (bestScore < score)
        {
            bestScore = score;
            bestScoreText.text = $"HIGH : {bestScore.ToString("N0")}M";
        }
    }
}