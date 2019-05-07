using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 0.15f;
    [SerializeField]
    float rotateSpeed = 2f;
    Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCannon(Input.GetAxis("Vertical"));
        RotateCannon(Input.GetAxis("Horizontal"));
    }

    private void MoveCannon(float direction)
    {
        var positionY = transform.position.y + (moveSpeed * direction);

        transform.position = new Vector2(transform.position.x, positionY);
    }

    private void RotateCannon(float direction)
    {
        var rotate = rotateSpeed * direction * -1;

        transform.Rotate(0, 0, rotate);
    }
}
