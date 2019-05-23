using System;
using UnityEngine;

[CreateAssetMenu]
public class CannonballVariable : ScriptableObject, ISerializationCallbackReceiver, ICannonball
{
    [SerializeField]
    GameObject Default;
    [NonSerialized]
    public GameObject Next;

    public void OnAfterDeserialize()
    {
        ResetNext();
    }

    public void OnBeforeSerialize()
    {
        ResetNext();
    }

    void ResetNext()
    {
        Next = Default;
    }

    public void Launch(Vector2 position, Vector2 velocity)
    {
        var cannonball = Instantiate(Next, position, Quaternion.identity);
        ICannonball ball = cannonball.GetComponent<ICannonball>();
        Debug.Log(cannonball);
        Debug.Log(position.x);

        if (ball == null)
            return;

        ball.Launch(position, velocity);
    }
}
