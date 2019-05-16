using System.Linq;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    [SerializeField]
    bool isPlayerOne = true;
    [SerializeField]
    float moveSpeed = 0.15f;
    [SerializeField]
    float rotateSpeed = 2f;
    [SerializeField]
    float velocity = 15f;
    [SerializeField]
    float initialMaxY = -8.3f;
    [SerializeField]
    float minY = -8.75f;
    [SerializeField]
    FloatVariable shotPower;
    float minimumShotPower = 0.3f;
    bool isCooling;
    string horizontal = "Horizontal";
    string vertical = "Vertical";
    string fire1 = "Fire1";
    public GameObject cannonball;

    void Start()
    {
        horizontal += isPlayerOne ? "_P1" : "_P2";
        vertical += isPlayerOne ? "_P1" : "_P2";
        fire1 += isPlayerOne ? "_P1" : "_P2";
    }

    void Update()
    {
        MoveCannon(Input.GetAxis(vertical));
        RotateCannon(Input.GetAxis(horizontal));

        if (isCooling) {
            CoolShot();
            return;
        }

        if (Input.GetButton(fire1))
        {
            ChargeShot();
        }

        if (Input.GetButtonUp(fire1)) {
            Fire();
            isCooling = true;
        }
    }

    private void ChargeShot() {
        shotPower.Value += .01f;

        if (shotPower.Value > 1) {
            shotPower.Value = 1;
        }
    }

    private void CoolShot()
    {
        shotPower.Value -= .01f;

        if (shotPower.Value < shotPower.InitialValue)
        {
            shotPower.Value = shotPower.InitialValue;
            isCooling = false;
        }
    }

    private void MoveCannon(float direction)
    {
        transform.position = new Vector2(transform.position.x, GetPositionY(direction));
    }

    private void RotateCannon(float direction)
    {
        transform.Rotate(0, 0, rotateSpeed * direction);
    }

    private void Fire() 
    {
        var spawnPoint = transform.Find("CannonballSpawnPoint").gameObject.transform;
        var ball = Instantiate(cannonball, new Vector2(spawnPoint.position.x, spawnPoint.position.y), Quaternion.identity);
        var rbody = ball.GetComponent<Rigidbody2D>();

        rbody.velocity = transform.right * velocity * (shotPower.Value + minimumShotPower);
    }

    private float GetPositionY(float direction)
    {
        var positionY = transform.position.y + (moveSpeed * direction);

        if (positionY < minY)
            return minY;

        var maxY = GetMaxY();

        if (positionY > maxY)
            return maxY;

        return positionY;
    }

    private float GetMaxY()
    {
        var player = isPlayerOne ? "P1" : "P2";
        var crateHolder = GameObject.Find("CrateHolder");
        var crateYs = crateHolder.GetComponentsInChildren<Transform>().ToList().Where(t => t.gameObject.tag == player).Select(t => t.position.y);

        return crateYs.Any() ? crateYs.Max() : initialMaxY;
    }
}
