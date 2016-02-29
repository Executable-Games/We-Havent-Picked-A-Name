using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class reloadScene : MonoBehaviour {

	private int scene;

	public void Reload(int sceneNumber)
	{
		SceneManager.LoadScene (sceneNumber);
	}
}
