using UnityEngine;

public class CannonScript : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 0.15f;
    [SerializeField]
    float rotateSpeed = 2f;
    [SerializeField]
    float velocity = 15f;
    [SerializeField]
    FloatVariable shotPower;
    public GameObject cannonball;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveCannon(Input.GetAxis("Vertical"));
        RotateCannon(Input.GetAxis("Horizontal"));

        if (Input.GetButton("Fire1"))
        {
            ChargeShot();
        }

        if (Input.GetButtonUp("Fire1")) {
            Fire();
            shotPower.ResetValue();
        }
    }

    private void ChargeShot() {
        shotPower.Value += .01f;

        if (shotPower.Value > 1) {
            shotPower.Value = 1;
        }
    }

    private void MoveCannon(float direction)
    {
        var positionY = transform.position.y + (moveSpeed * direction);

        transform.position = new Vector2(transform.position.x, positionY);
    }

    private void RotateCannon(float direction)
    {
        var rotate = rotateSpeed * direction * -1;

        transform.Rotate(0, 0, rotate);
    }

    private void Fire() {
        var ball = Instantiate(cannonball, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        var rbody = ball.GetComponent<Rigidbody2D>();

        rbody.velocity = transform.right * velocity * shotPower.Value;
    }
}
