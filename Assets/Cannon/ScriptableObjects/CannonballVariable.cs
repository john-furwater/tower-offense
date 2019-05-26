using System;
using UnityEngine;

[CreateAssetMenu]
public class CannonballVariable : ScriptableObject, ISerializationCallbackReceiver
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
}
