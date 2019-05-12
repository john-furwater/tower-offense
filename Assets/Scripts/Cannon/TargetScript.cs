using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        gameOver.SetActive(true);
    }
}
