using UnityEngine;

public class CannonballScript : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -20)
            Destroy(gameObject);
    }
}
