using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Start()
    {
        // Get VideoPlayer Component
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void PlayVideo()
    {
        Debug.Log("play!");

        if (videoPlayer != null)
        {
            // Play Video
            videoPlayer.Play();
        }
    }

    public void PauseVideo()
    {
        Debug.Log("pause!");
        if (videoPlayer != null)
        {
            // Pause Video
            videoPlayer.Pause();
        }
    }

    public void PlayOrPauseVideo()
    {
        if (GetComponent<VideoPlayer>().isPlaying)
        {
            PauseVideo();
        }
        else if(GetComponent<VideoPlayer>().isPaused)
        {
            PlayVideo();
        }

    }

    public void ReplayVideo()
    {
        if (videoPlayer != null)
        {
            // Replay Video
            videoPlayer.Stop();
            videoPlayer.Play();
        }
    }
}
