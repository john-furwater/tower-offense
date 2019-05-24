using UnityEngine;

public class RifleShotScript : MonoBehaviour, ICannonball
{
    [SerializeField]
    float multiplier = 8f;

    public void Launch(Transform parentTransform, float shotPower)
    {
        var cannonball = Instantiate(gameObject, parentTransform.position, Quaternion.identity);

        cannonball.GetComponent<Rigidbody2D>().velocity = parentTransform.right * shotPower * multiplier;
    }
}
