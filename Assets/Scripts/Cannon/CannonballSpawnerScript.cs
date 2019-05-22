using UnityEngine;

public class CannonballSpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject cannonball;
    [SerializeField]
    float minimumShotPower = 0.3f;
    [SerializeField]
    FloatVariable shotPower;
    [SerializeField]
    float velocity = 20f;

    void Start()
    {
    }

    public void SpawnCannonball()
    {
        var ball = Instantiate(cannonball, transform.position, Quaternion.identity);
        var rbody = ball.GetComponent<Rigidbody2D>();

        rbody.velocity = transform.right * GetFinalShotPower();
    }

    float GetFinalShotPower()
    {
        return velocity * (shotPower.Value + minimumShotPower);
    }
}
