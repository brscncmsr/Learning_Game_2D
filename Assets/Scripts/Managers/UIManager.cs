using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Main Menu")]
    public GameObject MainMenu;
    public GameObject Levels;
    [Header("Info Bar")]
    public GameObject soundOn;
    public GameObject soundOff;
    [Header("Compare")]
    public GameObject HintCanvas;
    public GameObject GameCanvas;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        MainMenu.SetActive(false);
        Levels.SetActive(true);
    }
    public void QuitButton()
    {
        GameManager.Instance.QuitGame();
    }
    public void BackMenuButton()
    {
        GameManager.Instance.BackToMenu();
    }
    public void SoundOnButton()
    {
        soundOff.SetActive(false);
        soundOn.SetActive(true);
    }
    public void SoundOffButton()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
    }
    public void LevelsButton()
    {
        string levelNum = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        GameManager.Instance.StartGame(levelNum);
   
    }
   
}
