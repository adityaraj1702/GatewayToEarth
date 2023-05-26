using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMScript : MonoBehaviour
{
    public Button play;
    public Button quit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
