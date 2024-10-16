using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject ground;
    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private float score;
    private float bestScore;

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        score = (ground.transform.position - this.gameObject.transform.position).magnitude;
        currentScoreText.text = $"{score.ToString("N0")}M";

        if (bestScore < score)
        {
            bestScore = score;
            bestScoreText.text = $"HIGH : {bestScore.ToString("N0")}M";
        }
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel > 0f)
        {
            _rb2d.AddForce(transform.up * SPEED, ForceMode2D.Impulse);
            fuel -= FUELPERSHOOT;
        }
        else
        {
            return;
        }
    }

    public void ReSetButton()
    {
        SceneManager.LoadScene("RocketLauncher");
    }
}
