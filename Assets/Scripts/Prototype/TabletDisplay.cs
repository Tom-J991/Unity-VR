using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabletDisplay : MonoBehaviour
{
    public Image sinBar;
    public Image miracleBar;
    public TMP_Text score;

    private EventSystem m_event;
    // Start is called before the first frame update
    void Start()
    {
        m_event = GameManager.Instance().eventSystem;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBars();   
    }

    public void ChangeBars()
    {
        sinBar.fillAmount = (float)m_event.GetSinners() / (float)m_event.regions.Count;
        miracleBar.fillAmount = (float)m_event.GetBelievers() / (float)m_event.regions.Count;

        score.text = "Score : " + m_event.score;
    }
}
