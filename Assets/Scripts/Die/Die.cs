using System;
using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject m_DieInstance;
    public DieColor m_Color; // Fixed
    public DieType m_Type;

    private SpriteRenderer m_SpriteRenderer;

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
        if (IsBrain)
        {
            if (IsGreen)
            {
                m_SpriteRenderer.sprite = m_BrainGreen;
            }
            else if (IsRed)
            {
                m_SpriteRenderer.sprite = m_BrainRed;
            }
            else if (IsYellow)
            {
                m_SpriteRenderer.sprite = m_BrainYellow;
            }
        }
        else if (IsFootprints)
        {
            if (IsGreen)
            {
                m_SpriteRenderer.sprite = m_FootprintsGreen;
            }
            else if (IsRed)
            {
                m_SpriteRenderer.sprite = m_FootprintsRed;
            }
            else if (IsYellow)
            {
                m_SpriteRenderer.sprite = m_FootprintsYellow;
            }
        }
        else if (IsShotgun)
        {
            if (IsGreen)
            {
                m_SpriteRenderer.sprite = m_ShotgunGreen;
            }
            else if (IsRed)
            {
                m_SpriteRenderer.sprite = m_ShotgunRed;
            }
            else if (IsYellow)
            {
                m_SpriteRenderer.sprite = m_ShotgunYellow;
            }
        }
    }

    public Die(DieColor color)
    {
        this.m_Color = color;
    }

    // Type properties
    public bool IsBrain
    {
        get { return m_Type == DieType.Brain; }
    }

    public bool IsFootprints
    {
        get { return m_Type == DieType.Footprints; }
    }

    public bool IsShotgun
    {
        get { return m_Type == DieType.Shotgun; }
    }

    // Color properties
    public bool IsGreen
    {
        get { return m_Color == DieColor.Green; }
    }

    public bool IsRed
    {
        get { return m_Color == DieColor.Red; }
    }

    public bool IsYellow
    {
        get { return m_Color == DieColor.Yellow; }
    }

    // Randomizes the type of die we are
    // e.g. Brain, Shotgun, Footprints
    public void Roll()
    {
        int roll = UnityEngine.Random.Range(1, 7);

        if (roll < 4 && m_Color == DieColor.Green)
        {
            m_Type = DieType.Brain;
            return;
        }

        if (roll < 3 && m_Color == DieColor.Yellow)
        {
            m_Type = DieType.Brain;
            return;
        }

        if (roll < 2 && m_Color == DieColor.Red)
        {
            m_Type = DieType.Brain;
            return;
        }

        if (roll < 5)
        {
            m_Type = DieType.Shotgun;
            return;
        }

        m_Type = DieType.Footprints;
    }

    public override string ToString()
    {
        string colorStr = "";
        string typeStr = "";

        switch (m_Color)
        {
            case DieColor.Green:
                colorStr = "green";
                break;
            case DieColor.Yellow:
                colorStr = "yellow";
                break;
            case DieColor.Red:
                colorStr = "red";
                break;
        }

        switch (m_Type)
        {
            case DieType.Brain:
                typeStr = "brain";
                break;
            case DieType.Footprints:
                typeStr = "footprints";
                break;
            case DieType.Shotgun:
                typeStr = "shotgun";
                break;
        }

        return String.Format(
            "Color: {0}, Type: {1}",
            colorStr,
            typeStr
        );
    }
}
