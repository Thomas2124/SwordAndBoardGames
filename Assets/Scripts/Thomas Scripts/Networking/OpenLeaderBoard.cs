using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLeaderBoard : MonoBehaviour
{
    public string leaderboardscene;
    public string backscene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene()
    {
        SceneManager.LoadScene(leaderboardscene);
    }

    public void backScene()
    {
        SceneManager.LoadScene(backscene);
    }
}
