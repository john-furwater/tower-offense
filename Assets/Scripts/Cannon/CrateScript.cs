using UnityEngine;

public class CrateScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        transform.SetParent(null, true);
    }
}
