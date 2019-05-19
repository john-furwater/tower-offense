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
        SetWinnerText();
        gameOver.SetActive(true);
    }

    void SetWinnerText()
    {
        var winner = isPlayerOne ? "One" : "Two";

        winnerText.text = "Player " + winner + " Wins";
    }
}
