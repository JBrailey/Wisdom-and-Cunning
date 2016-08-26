using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform mainMenu, optionsMenu;

  
	public void LoadScene(string name)
    {
        SceneManager.LoadScene(name); // Loads a scene with a specified name
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the game
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
