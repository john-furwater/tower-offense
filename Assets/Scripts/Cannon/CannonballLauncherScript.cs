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

    public void LaunchCannonball()
    {
        cannonball.Launch(transform.position, transform.right * GetFinalShotPower());
    }

    float GetFinalShotPower()
    {
        return velocity * (shotPower.Value + minimumShotPower);
    }
}
