using UnityEngine;

public class CannonballScript : MonoBehaviour, ICannonball
{
    public void Launch(Vector2 position, Vector2 velocity) 
    {
        Debug.Log(transform.position.x);
        var rbody = GetComponent<Rigidbody2D>();

        rbody.velocity = velocity;
    }
}
