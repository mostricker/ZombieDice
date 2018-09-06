using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBehavior : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    public DieColor m_Color;
    public DieType m_Type;

    public Sprite m_BrainGreen, m_BrainRed, m_BrainYellow,
        m_FootprintsGreen, m_FootprintsRed, m_FootprintsYellow,
        m_ShotgunGreen, m_ShotgunRed, m_ShotgunYellow;

    // Use this for initialization
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Green die
        if (m_Type == DieType.Brain)
        {
            if (m_Color == DieColor.Green)
            {
                m_SpriteRenderer.sprite = m_BrainGreen;
            }
            else if (m_Color == DieColor.Red)
            {
                m_SpriteRenderer.sprite = m_BrainRed;
            }
            else if (m_Color == DieColor.Yellow)
            {
                m_SpriteRenderer.sprite = m_BrainYellow;
            }
        }
        else if (m_Type == DieType.Footprints)
        {
            if (m_Color == DieColor.Green)
            {
                m_SpriteRenderer.sprite = m_FootprintsGreen;
            }
            else if (m_Color == DieColor.Red)
            {
                m_SpriteRenderer.sprite = m_FootprintsRed;
            }
            else if (m_Color == DieColor.Yellow)
            {
                m_SpriteRenderer.sprite = m_FootprintsYellow;
            }
        }
        else if (m_Type == DieType.Shotgun)
        {
            if (m_Color == DieColor.Green)
            {
                m_SpriteRenderer.sprite = m_ShotgunGreen;
            }
            else if (m_Color == DieColor.Red)
            {
                m_SpriteRenderer.sprite = m_ShotgunRed;
            }
            else if (m_Color == DieColor.Yellow)
            {
                m_SpriteRenderer.sprite = m_ShotgunYellow;
            }
        }
    }
}
