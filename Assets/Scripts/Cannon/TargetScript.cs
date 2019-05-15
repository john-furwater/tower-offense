using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.transform.name);
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name != "Cannonball(Clone)")
            return;
        
        Destroy(gameObject);
        gameOver.SetActive(true);
    }
}
