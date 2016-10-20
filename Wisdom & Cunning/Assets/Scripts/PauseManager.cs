using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Transform pauseMenu;
    public Canvas DialogueGUI;

    public bool pauseGame = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If Escape Key is pressed
        {
            pauseGame = !pauseGame; // Pause/Unpause the game
            DialogueGUI.gameObject.SetActive(true);
        }
        if (pauseGame == true) // If the game is paused
        {
            pauseMenu.gameObject.SetActive(true);
            DialogueGUI.gameObject.SetActive(false);
            Time.timeScale = 0; 
            // Set the timescale to 0 to pause the game
            // When code is added to allow camera movement put code in here to prevent it e.g
            // GameObject.Fine("Main Camera").GetComponent(MouseLook).enabled = false;
        }
        else // If the game isn't paused
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1; // Set timescale to 1 to make the game play normally
        }
    }
    public void ResumeGame()
    {
        DialogueGUI.gameObject.SetActive(true);
        pauseGame = false;
        
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name); // Loads a scene with a specified name
    }
}
