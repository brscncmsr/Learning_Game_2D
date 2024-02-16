using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareController : MonoBehaviour
{
    public GameObject Enviroment1;
    public GameObject Enviroment2;
    public GameObject Enviroment3;
    public GameObject Canvas;
    public GameObject Hint;
    public GameObject HintCanvas;
    public GameObject GameCanvas;
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public SoundManager.GameSounds sound;
    public SoundManager.GameSounds sound2;
    public PodController pod1;
    public PodController pod2;
    public PodController pod3;
    private int count = 0;
    private bool c1;
    private bool c2;
    private int tcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenDirective());
        sound = SoundManager.Instance.c1h;
        SoundManager.Instance.c1s1.PlaySound();
        sound2= SoundManager.Instance.c1su;
        pod1.isTrue = true;
        pod2.isTrue = false;
        pod3.isTrue = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (count == 3)
        {
            Hint.SetActive(true);
        }
        
    }
    public void Pots()
    {
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<PodController>().isTrue)
        {
            TrueAnswer();
        }
        else
        {
            FalseAnswer();
        }
    }
    IEnumerator OpenDirective()
    {
        yield return new WaitForSeconds(SoundManager.Instance.c1s1.clip.length);
        Enviroment1.SetActive(false);
        Enviroment2.SetActive(true);
        StartCoroutine(OpenDirective2());
        SoundManager.Instance.c1s2.PlaySound();
    }
    IEnumerator OpenDirective2()
    {
        yield return new WaitForSeconds(SoundManager.Instance.c1s2.clip.length);
        Enviroment2.SetActive(false);
        Canvas.SetActive(true);

        SoundManager.Instance.c1g.PlaySound();
    }
    public void TrueAnswer()
    {
        tcount++;
        if (tcount == 1)
        {
            Enviroment2.SetActive(true);
        }
        else if (tcount == 2){
            Enviroment3.SetActive(true);
        }
        
        Canvas.SetActive(false);
        Hint.SetActive(false);
        StartNewGoal();
    }
    public void FalseAnswer()
    {
        count++;
    }
    public void StartNewGoal()
    {
        sound2.PlaySound();
        sound = SoundManager.Instance.c2h;
        count = 0;
        pod1.isTrue = false;
        pod2.isTrue = false;
        pod3.isTrue = true;
        sound2 = SoundManager.Instance.c2su;
        StartCoroutine(OpenDirective1());
    }
    IEnumerator OpenDirective1()
    {
        yield return new WaitForSeconds(SoundManager.Instance.c1su.clip.length);
        Enviroment2.SetActive(false);
        Canvas.SetActive(true);
        SoundManager.Instance.c2g.PlaySound();
    }
    public void HintButton()
    {
        HintCanvas.SetActive(true);
        SoundManager.Instance.h1.PlaySound();
        h1.SetActive(true);
        GameCanvas.SetActive(false);
        StartCoroutine(Hint2());
      
    }
    public void CloseHintButton()
    {
        HintCanvas.SetActive(false);

    }
    IEnumerator Hint2()
    {
        Debug.Log("a");
        yield return new WaitForSeconds(SoundManager.Instance.h1.clip.length);
        SoundManager.Instance.h2.PlaySound();
        StartCoroutine(Hint3());
        h2.SetActive(true);
    }
    IEnumerator Hint3()
    {
        Debug.Log("a");
        yield return new WaitForSeconds(SoundManager.Instance.h2.clip.length);
        SoundManager.Instance.h3.PlaySound();
        h3.SetActive(true);
        StartCoroutine(Hint4());
    }
    IEnumerator Hint4()
    {
        Debug.Log("a");
        yield return new WaitForSeconds(SoundManager.Instance.h3.clip.length);
        SoundManager.Instance.h4.PlaySound();
        h3.SetActive(true);
        StartCoroutine(CloseHint());
    }


    IEnumerator CloseHint()
    {
        Debug.Log("a");
        yield return new WaitForSeconds(SoundManager.Instance.h3.clip.length);
        HintCanvas.SetActive(false);
        GameCanvas.SetActive(true);
    }
}
