using UnityEngine;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour
{
    [SerializeField]
    private Button _soloModeStartButton = default;
    [SerializeField]
    private Button _clientStartButton = default;
    [SerializeField]
    private Button _serverStartButton = default;

    [SerializeField]
    private Slider _bgmSlider = default;
    [SerializeField]
    private Slider _seSlider = default;

    private void Start()
    {
        SetupUI();

        Fade.Instance.StartFadeIn();
    }

    private void SetupUI()
    {
        if (_soloModeStartButton != null)
        {
            _soloModeStartButton.onClick.AddListener(() =>
            {
                SceneLoader.FadeLoad(SceneName.InGameSolo);
            });
        }
        if (_clientStartButton != null)
        {
            _clientStartButton.onClick.AddListener(() =>
            {
                SceneLoader.FadeLoad(SceneName.InGameClient);
            });
        }
        if (_serverStartButton != null)
        {
            _serverStartButton.onClick.AddListener(() =>
            {
                SceneLoader.FadeLoad(SceneName.InGameServer);
            });
        }
        if (_bgmSlider != null) { _bgmSlider.onValueChanged.AddListener(AudioManager.Instance.VolumeSettingBGM); }
        if (_seSlider != null) { _seSlider.onValueChanged.AddListener(AudioManager.Instance.VolumeSettingSE); }
    }
}
