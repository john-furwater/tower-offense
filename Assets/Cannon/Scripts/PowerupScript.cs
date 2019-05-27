using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField]
    GameObject nextShot;
    [SerializeField]
    CannonballVariable playerOneCannonball;
    [SerializeField]
    CannonballVariable playerTwoCannonball;

    void OnCollisionEnter2D(Collision2D other)
    {
        var cannonball = other.gameObject.GetComponent<ICannonball>();
        Debug.Log(cannonball);
        if (cannonball == null)
            return;

        var playerCannonball = cannonball.IsPlayerOne ? playerOneCannonball : playerTwoCannonball;
        
        playerCannonball.Next = nextShot;
        Destroy(gameObject);
    }
}
