using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;
    
    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel > 0f)
        {
            _rb2d.AddForce(transform.up * SPEED, ForceMode2D.Impulse);
            fuel -= FUELPERSHOOT;
            Debug.Log("Click");
        }
        else
        {
            return;
        }
    }
}
