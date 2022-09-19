using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void Pachinko()
    {
        SceneManager.LoadScene("Pachinko Game");
    }
    public void Stock()
    {
        SceneManager.LoadScene("Stock Counter");
    }
    public void basketball()
    {
        SceneManager.LoadScene("Basketball");
    }
    public void CannonShoot()
    {
        SceneManager.LoadScene("Cannon Aim");
    }
    public void MazeCreator()
    {
        SceneManager.LoadScene("Maze Creation");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
