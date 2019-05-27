using UnityEngine;

public class RifleShotScript : CannonballScript, ICannonball
{
    [SerializeField]
    float multiplier = 8f;

    public override void Launch(Transform parentTransform, float shotPower)
    {
        var cannonball = Instantiate(gameObject, parentTransform.position, Quaternion.identity);

        cannonball.GetComponent<CannonballScript>().IsPlayerOne = IsPlayerOne;
        cannonball.GetComponent<Rigidbody2D>().velocity = parentTransform.right * shotPower * multiplier;
    }
}
