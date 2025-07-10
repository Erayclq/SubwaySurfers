using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GAME");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
