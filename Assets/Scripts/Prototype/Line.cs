using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Image icon;

    public List<Sprite> sinIcons = new();
    public List<Sprite> miracleIcons = new();

    private LineRenderer m_line;
    // Start is called before the first frame update
    void Start()
    {
        m_line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_line.positionCount = 2;
        m_line.SetPosition(0, pointA.position);
        m_line.SetPosition(1, pointB.position);
    }

    public void ChangeIcon(int sinLevel,int miracleLevel, Vector3 regionPos)
    {
        pointB.transform.position = new Vector3(regionPos.x - 0.25f, regionPos.y, regionPos.z + 0.5f);
        if(sinLevel > 0)
        {
            icon.sprite = sinIcons[sinLevel - 1];
        }
        else
        {
            icon.sprite = miracleIcons[miracleLevel - 1];
        }
    }
}
