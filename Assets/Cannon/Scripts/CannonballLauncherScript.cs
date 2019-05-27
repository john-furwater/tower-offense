using UnityEngine;

public class CannonballLauncherScript : MonoBehaviour
{
    [SerializeField]
    CannonballVariable cannonball;
    [SerializeField]
    float minimumShotPower = 0.3f;
    [SerializeField]
    FloatVariable shotPower;
    [SerializeField]
    float velocity = 20f;
    [SerializeField]
    bool isPlayerOne = true;

    public void LaunchCannonball()
    {
        var next = cannonball.Next.GetComponent<ICannonball>();

        if (next == null)
            return;

        next.IsPlayerOne = isPlayerOne;
        next.Launch(transform, GetFinalShotPower());
    }

    float GetFinalShotPower()
    {
        return velocity * (shotPower.Value + minimumShotPower);
    }
}
