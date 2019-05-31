using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    bool isPlayerOne = true;
    [SerializeField]
    Text winnerText;
    AudioSource audioSource;
    ParticleSystem particleSystem;
    Transform _transform;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
        _transform = transform;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var cannonball = other.transform.GetComponent<ICannonball>();

        if (cannonball == null)
            return;

        audioSource.Play();
        particleSystem.Play();
        _transform.GetComponent<SpriteRenderer>().enabled = false;
        _transform.GetComponent<CircleCollider2D>().enabled = false;
        SetWinnerText();
        gameOver.SetActive(true);
    }

    void SetWinnerText()
    {
        var winner = isPlayerOne ? "One" : "Two";

        winnerText.text = "Player " + winner + " Wins";
    }
}
