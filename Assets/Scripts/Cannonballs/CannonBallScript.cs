using UnityEngine;

public class CannonballScript : MonoBehaviour, ICannonball
{
    public void Launch(Vector2 position, Vector2 velocity) 
    {
        var cannonball = Instantiate(gameObject, position, Quaternion.identity);

        cannonball.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
