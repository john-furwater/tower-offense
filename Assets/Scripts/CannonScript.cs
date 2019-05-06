using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    [SerializeField]
    float speed = 0.2f;
    Transform myTransform;
    [SerializeField]
    float maxDistance = 5.26f;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
            MoveCannon(Input.GetAxis("Vertical"));
    }

    private void MoveCannon(float direction)
    {
        if(myTransform != null)
            myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + (speed * direction));
    }
}
