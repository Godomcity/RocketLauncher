using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    RocketEnergySystem energySystem;

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        energySystem = GameObject.Find("RoketEnergySystem").GetComponent<RocketEnergySystem>();
    }

    private void Update()
    {
        if (fuel < 100)
        {
            fuel += 0.01f;
            energySystem.faillAmount.value += 0.01f;
        }
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel > 0f)
        {
            
            _rb2d.AddForce(transform.up * SPEED, ForceMode2D.Impulse);
            fuel -= FUELPERSHOOT;
            energySystem.faillAmount.value -= FUELPERSHOOT;
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