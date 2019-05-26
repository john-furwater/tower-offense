using UnityEngine;

public class SpreadShotScript : MonoBehaviour, ICannonball
{
    [SerializeField]
    float positionOffset = 0.5f;
    [SerializeField]
    float shotAngleOffset = 10f;

    public void Launch(Transform parentTransform, float shotPower)
    {
        var upper = Instantiate(gameObject, parentTransform.TransformPoint(Vector3.up * positionOffset * 2), parentTransform.rotation);
        var uppermid = Instantiate(gameObject, parentTransform.TransformPoint(Vector3.up * positionOffset), parentTransform.rotation);
        var mid = Instantiate(gameObject, parentTransform.position, parentTransform.rotation);
        var lowermid = Instantiate(gameObject, parentTransform.TransformPoint(Vector3.up * -positionOffset), parentTransform.rotation);
        var lower = Instantiate(gameObject, parentTransform.TransformPoint(Vector3.up * -positionOffset * 2), parentTransform.rotation);

        upper.transform.Rotate(0, 0, shotAngleOffset * 2);
        uppermid.transform.Rotate(0, 0, shotAngleOffset);
        lowermid.transform.Rotate(0, 0, -shotAngleOffset);
        lower.transform.Rotate(0, 0, -shotAngleOffset * 2);
        upper.GetComponent<Rigidbody2D>().velocity = upper.transform.right * shotPower;
        uppermid.GetComponent<Rigidbody2D>().velocity = uppermid.transform.right * shotPower;
        mid.GetComponent<Rigidbody2D>().velocity = mid.transform.right * shotPower;
        lowermid.GetComponent<Rigidbody2D>().velocity = lowermid.transform.right * shotPower;
        lower.GetComponent<Rigidbody2D>().velocity = lower.transform.right * shotPower;
    }

    public Vector2 GetUpperPosition(Transform parentTransform)
    {
        return parentTransform.TransformPoint(Vector3.up * positionOffset);
    }

    public Vector2 GetLowerPosition(Transform parentTransform)
    {
        return parentTransform.TransformPoint(-Vector3.up * positionOffset);
    }
}
