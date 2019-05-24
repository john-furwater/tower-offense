using UnityEngine;

public class CannonballScript : MonoBehaviour, ICannonball
{
    public void Launch(Transform parentTransform, float shotPower) 
    {
        var cannonball = Instantiate(gameObject, parentTransform.position, Quaternion.identity);

        cannonball.GetComponent<Rigidbody2D>().velocity = parentTransform.right * shotPower;
    }
}
