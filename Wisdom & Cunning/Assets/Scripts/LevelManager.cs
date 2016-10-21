using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform mainMenu, levelSelect;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

  
	public void LoadScene(string name)
    {
        SceneManager.LoadScene(name); // Loads a scene with a specified name
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the game
    }

    public void LevelSelect(bool toggle)
    {
        if (toggle == true) // If the options menu is toggled load the options menu and deactivate the main menu
        {
            levelSelect.gameObject.SetActive(toggle);
            mainMenu.gameObject.SetActive(false);
        }
        else // Otherwise deactivate the options menu and activate the main menu
        {
            levelSelect.gameObject.SetActive(toggle);
            mainMenu.gameObject.SetActive(true);
        }
    }
    
}
