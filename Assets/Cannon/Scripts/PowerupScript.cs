using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField]
    GameObject nextShot;
    [SerializeField]
    CannonballVariable playerOneCannonball;
    [SerializeField]
    CannonballVariable playerTwoCannonball;

    void OnTriggerEnter2D(Collider2D other)
    {
        var otherGameObject = other.gameObject;
        var cannonball = otherGameObject.GetComponent<ICannonball>();

        if (cannonball == null)
            return;

        var playerCannonball = cannonball.IsPlayerOne ? playerOneCannonball : playerTwoCannonball;
        
        playerCannonball.Next = nextShot;
        Destroy(gameObject);
        Destroy(otherGameObject);
    }
}
