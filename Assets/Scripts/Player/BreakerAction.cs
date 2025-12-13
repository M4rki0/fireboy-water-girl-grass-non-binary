using UnityEngine;

public class BreakerAction : MonoBehaviour, ICharacterAction
{
    public void DoAction()
    {
        Debug.Log("Breaker smashing!");
        // TODO: break walls, ropes, objects
    }
}