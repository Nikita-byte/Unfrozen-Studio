using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SettingsPanel : BasePanel
{
    [SerializeField] private Button _back;
    [SerializeField] private Button _soundOn;
    [SerializeField] private Button _soundOff;
    [SerializeField] private Slider _soundVolume;
 
    private void Awake()
    {
        _back.onClick.AddListener(() => ScreenInterface.Instance.Execute(PanelType.MainMenu));

        _soundOn.onClick.AddListener(() => SoundOn());
        _soundOff.onClick.AddListener(() => SoundOff());

        SetVolume();
        SoundOn();
        
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }

    public void SetScreen(Sprite screen)
    {
        GetComponent<Image>().sprite = screen;
    }

    public void SetBackButton(Sprite sprite)
    {
        _back.GetComponent<Image>().sprite = sprite;
    }

    public void SetSounOnButton(Sprite sprite)
    {
        _soundOn.GetComponent<Image>().sprite = sprite;
    }

    public void SetSoundOffButton(Sprite sprite)
    {
        _soundOff.GetComponent<Image>().sprite = sprite;
    }

    public void ChangeValue(float value)
    {
        SoundManager.Instance.SetVolume(value);
    }

    private void SetVolume()
    {
        SoundManager.Instance.SetVolume(1);
    }

    private void SoundOn()
    {
        //SoundManager.Instance.TurnOn();
        float volume = PlayerPrefs.GetFloat("Volume", 1);
        _soundVolume.value = volume;
        _soundOn.gameObject.SetActive(false);
        _soundOff.gameObject.SetActive(true);
    }

    private void SoundOff()
    {
        //SoundManager.Instance.TurnOff();
        PlayerPrefs.SetFloat("Volume", _soundVolume.value);
        _soundVolume.value = 0;
        _soundOn.gameObject.SetActive(true);
        _soundOff.gameObject.SetActive(false);
    }
}