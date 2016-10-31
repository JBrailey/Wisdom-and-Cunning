using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    public float timer;
    public string LevelToLoad;

	// Use this for initialization
	void Start () {
        StartCoroutine_Auto(Load());
	}
	IEnumerator Load()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(LevelToLoad);
    }

}
