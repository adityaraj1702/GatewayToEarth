using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject aimPanel;
    public GameObject gameOverCanvas;
    public PlayerMotor playerhealth;
    public GameObject playerHealthBar;
    public EnemyController enemyhealth;
    public GameObject levelCompletePanel;
    public GameObject portal;
    public Collider winCollision; 
    public Transform player;
    public SoundManager sound;
    

    void Start()
    {
        // playerObject.transform.position = playerSpawn[level].position;
        pauseMenu.SetActive(false); // Hide resume button by default
        gameOverCanvas.SetActive(false);
        portal.SetActive(false);
        aimPanel.SetActive(true);
        levelCompletePanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true); // Show resume button
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false); // Hide resume button
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReplayLevel(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel(){
        Time.timeScale =1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            aimPanel.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
        if(Input.GetButtonDown("Fire1") && Time.timeScale == 1){
            sound.Play("Shoot");
        }

        if (playerhealth.health <= 0)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        if(enemyhealth.health <= 0)
        {
            portal.SetActive(true);

        }

        if (winCollision.bounds.Intersects(player.GetComponent<Collider>().bounds))
        {
            // if (hasWon)
            // {
                sound.Stop("Theme");
                sound.Play("Win");
                playerHealthBar.SetActive(false);
                levelCompletePanel.SetActive(true);
                Time.timeScale = 0;
                
            // }
        }

        if(Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }
    
}
