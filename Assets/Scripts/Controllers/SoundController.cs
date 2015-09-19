using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    
    private AudioSource _normalMusicAudioSource;
    private AudioSource _battleMusicAudioSource;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        var normalMusic = Instantiate(Resources.Load<GameObject>(StateController.Instance.CurrentLevel.MusicNormalResource));
        var battleMusic = Instantiate(Resources.Load<GameObject>(StateController.Instance.CurrentLevel.MusicBattleResource));
        _normalMusicAudioSource = normalMusic.GetComponent<AudioSource>();
        _battleMusicAudioSource = battleMusic.GetComponent<AudioSource>();
    }
    
    public void SwitchToBattleMusic()
    {
        _normalMusicAudioSource.Stop();
        _battleMusicAudioSource.Play();
    }

    public void SwitchToNormalMusic()
    {
        _battleMusicAudioSource.Stop();
        _normalMusicAudioSource.Play();
    }
}
