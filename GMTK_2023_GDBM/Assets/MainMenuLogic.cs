using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    // Start is called before the first frame update
    void Start()
    {
        _slider.onValueChanged.AddListener((v) => {
            _sliderText.text = v.ToString("0");
            ChangeVolume(v);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene("MainLevel");
    }

    public void StartGameAI(){
        SceneManager.LoadScene("AILevel");
    }

    public void ChangeVolume(float value){
        
    }

    public void ExitGame()
    {
        Screen.fullScreen = false;
    }

}
