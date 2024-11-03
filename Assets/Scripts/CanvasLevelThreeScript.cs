using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLevelThreeScript : MonoBehaviour
{
   public void RestartLevel()
    {
        SceneManager.LoadScene("SceneThree");
        Time.timeScale = 1;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SceneOne");
        Time.timeScale = 1;
    }
}
