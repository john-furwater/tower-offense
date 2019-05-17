using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != "Cannonball(Clone)")
            return;

        audioSource.Play();
        transform.localScale = new Vector2(0, 0);
        gameOver.SetActive(true);
    }
}
