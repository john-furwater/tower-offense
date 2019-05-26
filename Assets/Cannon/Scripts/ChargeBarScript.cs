using UnityEngine;

public class ChargeBarScript : MonoBehaviour
{
    [SerializeField]
    FloatVariable shotPower;
    float initialScale;

    void Start()
    {
        initialScale = transform.localScale.x;
    }

    void Update()
    {
        transform.localScale = new Vector3(initialScale * shotPower.Value, transform.localScale.y, transform.localScale.z);
    }
}
