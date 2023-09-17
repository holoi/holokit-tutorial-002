using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Start()
    {
        // 获取VideoPlayer组件
        videoPlayer = GetComponent<VideoPlayer>();

        // 设置视频循环播放
        //videoPlayer.isLooping = false;
    }

    public void PlayVideo()
    {
        if (videoPlayer != null)
        {
            // 播放视频
            videoPlayer.Play();
        }
    }

    public void PauseVideo()
    {
        if (videoPlayer != null)
        {
            // 暂停视频
            videoPlayer.Pause();
        }
    }

    public void PlayOrPauseVideo()
    {
        if (GetComponent<VideoPlayer>().isPlaying)
        {
            PauseVideo();
        }
        if(GetComponent<VideoPlayer>().isPaused)
        {
            PlayVideo();
        }

    }

    public void ReplayVideo()
    {
        if (videoPlayer != null)
        {
            // 重播视频（回到视频的开始）
            videoPlayer.Stop();
            videoPlayer.Play();
        }
    }
}
