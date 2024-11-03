using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
   public void RestartLevel()
    {
        SceneManager.LoadScene("SceneTwo");
        Time.timeScale = 1;
    }
}
