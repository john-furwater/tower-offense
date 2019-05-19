using UnityEngine;

public class CrateScript : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        transform.SetParent(GameObject.Find("CrateHolder").transform, true);
        audioSource.Play();
    }
}
