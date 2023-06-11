using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour
{
    [SerializeField] 
    VideoPlayer myVideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        myVideoPlayer.loopPointReached += EndCutscene;
    }

    // Update is called once per frame
    void EndCutscene(VideoPlayer vp)
    {
        Debug.Log("Cutscene finish");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
