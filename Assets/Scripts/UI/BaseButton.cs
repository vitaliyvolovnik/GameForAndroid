using UnityEngine.SceneManagement;
using UnityEngine;

public class BaseButton : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
