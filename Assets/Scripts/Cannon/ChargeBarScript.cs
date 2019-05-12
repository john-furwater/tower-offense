using UnityEngine;

public class ChargeBarScript : MonoBehaviour
{
    [SerializeField]
    FloatVariable shotPower;
    float initialScale;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(initialScale * shotPower.Value, transform.localScale.y, transform.localScale.z);
    }
}
