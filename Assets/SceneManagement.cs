using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void PlayGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //hier verwijzen we naar de puzzelpagina's
    public void loadLevelSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void loadPlugkraanLevel()
    {
        SceneManager.LoadScene(2);

    }

    public void loadPlugkraanPuzzel()
    {
        SceneManager.LoadScene(3);
    }

    public void loadPlugkraanQuiz()
    {
        SceneManager.LoadScene(4);
    }

    public void loadDoorverwijsPagina()
    {
        SceneManager.LoadScene(5);
    }

    public void loadTussenpaginaQuiz()
    {
        SceneManager.LoadScene(6);
    }
// hier verwijzen we naar de quizpagina's
    public void loadKogelKraanQuiz()
    {
        SceneManager.LoadScene(7);
    }
    public void loadTerugslagKlepQuiz()
    {
        SceneManager.LoadScene(8);
    }
    public void loadVeerVeiligheidsToestelQuiz()
    {
        SceneManager.LoadScene(9);
    }
    public void loadVlinderKlepQuiz()
    {
        SceneManager.LoadScene(10);
    }

    public void loadKlepAfsluiterQuiz()
    {
        SceneManager.LoadScene(10);
    }
    //einde quizpagina's

    //verwijzen naar de intro paginas
    public void loadKogelkraanIntro()
    {
        SceneManager.LoadScene(11);
    }
    public void loadVlinderkraanIntro()
    {
        SceneManager.LoadScene(12);
    }
    public void loadPlugkraanIntro()
    {
        SceneManager.LoadScene(13);
    }
    public void loadMembraanAfsluiter()
    {
        SceneManager.LoadScene(14);
    }
    public void loadSchuifAfsluiter()
    {
        SceneManager.LoadScene(15);
    }

    public void loadKlepAfsluiter()
    {
        SceneManager.LoadScene(16);
    }

    public void loadTerugslagKlep()
    {
        SceneManager.LoadScene(17);
    }

    public void loadVeerveiligheidToestel()
    {
        SceneManager.LoadScene(18);
    }

    public void loadLeidingfilter()
    {
        SceneManager.LoadScene(19);
    }

    


    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
