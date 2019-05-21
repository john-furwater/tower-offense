using UnityEngine;

public class CrateScript : MonoBehaviour
{
    AudioSource audioSource;

    public bool canControl;

    void Start()
    {
        canControl = true;
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        canControl = false;
        transform.SetParent(GameObject.Find("CrateHolder").transform, true);
        audioSource.Play();
    }
}
