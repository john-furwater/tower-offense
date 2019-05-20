using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    GameEvent Event;
    [SerializeField]
    UnityEvent Response;

    public void OnEnable()
    {
        Event.AddListener(this);
    }

    public void OnDisable()
    {
        Event.RemoveListener(this);
    }

    public void OnEventRaised() 
    {
        Response.Invoke();
    }
}
