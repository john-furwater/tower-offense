using UnityEngine;

public class DestroyOffScreenScript : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -20)
            Destroy(gameObject);
    }
}
