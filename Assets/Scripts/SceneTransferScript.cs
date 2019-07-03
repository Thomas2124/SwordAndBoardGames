using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransferScript : MonoBehaviour
{
	public string nameOfScene;
	
	public void SceneSwitch()
	{
		SceneManager.LoadScene(nameOfScene);
	}
}
