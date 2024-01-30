using UnityEngine;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private Button _startButton = default;

    private void Start()
    {
        if (_startButton != null)
        {
            _startButton.onClick.AddListener(() =>
            {
                SceneLoader.FadeLoad(SceneName.Home);
            });
        }
        Fade.Instance.StartFadeIn();
    }
}
