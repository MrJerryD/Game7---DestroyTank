using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void exitAll()
    {
        Application.Quit();
    }
}
