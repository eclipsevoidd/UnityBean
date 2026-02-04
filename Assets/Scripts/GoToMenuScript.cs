using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}