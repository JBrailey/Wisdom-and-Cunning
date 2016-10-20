using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter(Collider collider) // Function fires upon entering a trigger collider
    {
        if (collider.gameObject.tag.Equals("Fox"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
