using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Transform mainMenu, optionsMenu;
    public bool pauseGame = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If Escape Key is pressed
        {
            pauseGame = !pauseGame; // Pause/Unpause the game
        }
        if (pauseGame == true) // If the game is paused
        {
            if (optionsMenu.gameObject.gameObject.activeInHierarchy == false) // Check if Options menu isn't open
            {
                mainMenu.gameObject.SetActive(true);
            }
            else // Otherwise when it is
            {
                mainMenu.gameObject.SetActive(false); // Disable the main menu
            }
            Time.timeScale = 0; // Set the timescale to 0 to pause the game
            //  When code is added to allow camera movement put code in here to prevent it e.g
            //  GameObject.Fine("Main Camera").GetComponent(MouseLook).enabled = false;
        }
        else // If the game isn't paused
        {
            mainMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(false);
            Time.timeScale = 1; // Set timescale to 1 to make the game play normally
        }
    }
    public void ResumeGame()
    {
        pauseGame = false;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name); // Loads a scene with a specified name
    }
    public void OptionsMenu(bool toggle)
    {
        if (toggle == true) // If the options menu is toggled load the options menu and deactivate the main menu
        {
            optionsMenu.gameObject.SetActive(toggle);
            mainMenu.gameObject.SetActive(false);
        }
        else // Otherwise deactivate the options menu and activate the main menu
        {
            optionsMenu.gameObject.SetActive(toggle);
            mainMenu.gameObject.SetActive(true);
        }
    }
}
