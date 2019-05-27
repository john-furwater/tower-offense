using System.Collections;
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
    float initialMaxY = -8.3f;
    [SerializeField]
    float minY = -8.75f;
    [SerializeField]
    FloatVariable shotPower;
    [SerializeField]
    GameEvent CannonFiredEvent;
    bool isCooling;
    string horizontal = "Horizontal";
    string vertical = "Vertical";
    string fire1 = "Fire1";
    [SerializeField]
    float spinTimeModifier = .25f;
    float spinTime = .25f;
    [SerializeField]
    float spinSpeedModifier = .25f;
    float spinSpeed = .25f;
    Transform _transform;
    GameObject crateHolder;

    void Start()
    {
        _transform = transform;
        crateHolder = GameObject.Find("CrateHolder");
        horizontal += isPlayerOne ? "_P1" : "_P2";
        vertical += isPlayerOne ? "_P1" : "_P2";
        fire1 += isPlayerOne ? "_P1" : "_P2";
    }

    void Update()
    {
        MoveCannon(Input.GetAxis(vertical));
        RotateCannon(Input.GetAxis(horizontal));

        if (isCooling)
        {
            CoolShot();
            return;
        }

        if (Input.GetButton(fire1))
        {
            ChargeShot();
        }

        if (Input.GetButtonUp(fire1))
        {
            Fire();
            isCooling = true;
        }
    }

    private void ChargeShot()
    {
        shotPower.Value += .01f;

        if (shotPower.Value > 1)
        {
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
        _transform.position = new Vector2(_transform.position.x, GetPositionY(direction));
    }

    private void RotateCannon(float direction)
    {
        _transform.Rotate(0, 0, rotateSpeed * direction);
    }

    private void Fire()
    {
        CannonFiredEvent.Raise();
    }

    private float GetPositionY(float direction)
    {
        var positionY = _transform.position.y + (moveSpeed * direction);

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

        if (crateHolder == null)
            return initialMaxY;

        var crateYs = crateHolder.GetComponentsInChildren<Transform>().ToList().Where(t => t.gameObject.tag == player).Select(t => t.position.y);

        return crateYs.Any() ? crateYs.Max() : initialMaxY;
    }

    IEnumerator Spin()
    {
        var time = 0f;
        var turnIncrement = new Vector3(0, 0, spinSpeed * Time.deltaTime);

        while (time < spinTime)
        {
            time += Time.deltaTime;
            _transform.Rotate(turnIncrement);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var cannonball = other.transform.GetComponent<ICannonball>();

        if (cannonball == null || cannonball.IsPlayerOne == isPlayerOne)
            return;

        spinTime = other.relativeVelocity.magnitude * spinTimeModifier;
        spinSpeed = other.relativeVelocity.magnitude * spinSpeedModifier;
        StartCoroutine(Spin());
    }
}
