using UnityEngine;

public class CannonballScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
