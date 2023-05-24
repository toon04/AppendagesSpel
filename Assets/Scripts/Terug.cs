using UnityEngine;
using UnityEngine.SceneManagement;

public class Terug : MonoBehaviour
{
    public void Back() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    public void naarLevelSelect()
    {
        SceneManager.LoadScene("Assets/Scenes/Level Select/LevelSelect.unity");
    }

    public void naarInstellingen()
    {
        SceneManager.LoadScene("Assets/Scenes/Instellingen/Instellingen.unity");
    }
}
