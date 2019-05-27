using UnityEngine;

public class SpreadShotScript : CannonballScript, ICannonball
{
    [SerializeField]
    float positionOffset = 0.5f;
    [SerializeField]
    float shotAngleOffset = 10f;
    float shotPower;

    public override void Launch(Transform parentTransform, float shotPower)
    {
        var upper = Instantiate(gameObject, parentTransform.TransformPoint(Vector3.up * positionOffset * 2), parentTransform.rotation);
        var uppermid = Instantiate(gameObject, parentTransform.TransformPoint(Vector3.up * positionOffset), parentTransform.rotation);
        var mid = Instantiate(gameObject, parentTransform.position, parentTransform.rotation);
        var lowermid = Instantiate(gameObject, parentTransform.TransformPoint(Vector3.up * -positionOffset), parentTransform.rotation);
        var lower = Instantiate(gameObject, parentTransform.TransformPoint(Vector3.up * -positionOffset * 2), parentTransform.rotation);

        this.shotPower = shotPower;

        RotateAndLaunch(upper, 2);
        RotateAndLaunch(uppermid, 1);
        RotateAndLaunch(mid, 0);
        RotateAndLaunch(lowermid, -1);
        RotateAndLaunch(lower, -2);
    }

    private void RotateAndLaunch(GameObject cannonball, float angleModifier) {
        var _transform = cannonball.transform;

        cannonball.GetComponent<CannonballScript>().IsPlayerOne = IsPlayerOne;
        _transform.Rotate(0, 0, shotAngleOffset * angleModifier);
        cannonball.GetComponent<Rigidbody2D>().velocity = _transform.right * shotPower;
    }
}
