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
        ResetValue();
    }

    public void ResetValue() 
    {
        Value = InitialValue;
    }
}
