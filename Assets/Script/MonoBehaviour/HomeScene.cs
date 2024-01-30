using UnityEngine;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour
{
    [SerializeField]
    private Button _gamePlayButton = default;
    [SerializeField]
    private Button _networkDemoButton = default;
    [SerializeField]
    private Slider _bgmSlider = default;
    [SerializeField]
    private Slider _seSlider = default;

    private void Start()
    {
        if (_gamePlayButton != null)
        {
            _gamePlayButton.onClick.AddListener(() =>
            {
                SceneLoader.FadeLoad(SceneName.InGame);
            });
        }
        if (_networkDemoButton != null)
        {
            _networkDemoButton.onClick.AddListener(() =>
            {
                SceneLoader.FadeLoad(SceneName.NetworkDemo);
            });
        }
        if (_bgmSlider != null) { _bgmSlider.onValueChanged.AddListener(AudioManager.Instance.VolumeSettingBGM); }
        if (_seSlider != null) { _seSlider.onValueChanged.AddListener(AudioManager.Instance.VolumeSettingSE); }

        Fade.Instance.StartFadeIn();
    }
}
