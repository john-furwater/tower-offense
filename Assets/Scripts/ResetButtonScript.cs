using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButtonScript : MonoBehaviour
{
    public void OnClicked() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
