using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;
    [NonSerialized]
    public float Value;

    public void OnAfterDeserialize()
    {
        ResetValue();
    }

    public void OnBeforeSerialize()
    {
    }

    public void ResetValue() 
    {
        Value = InitialValue;
    }
}
