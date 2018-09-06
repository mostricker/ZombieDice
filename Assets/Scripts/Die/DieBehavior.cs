using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBehavior : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    public DieColor myColor = DieColor.Green;

    public Sprite m_GreenSprite;
    public Sprite m_RedSprite;
    public Sprite m_YellowSprite;

    // Use this for initialization
    void Start () {
        Debug.Log("I am alive!");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Change internal state
        if (Input.GetButtonDown("change_die_color"))
        {
            myColor = myColor.Next();
        }
    
        // Render changes
        if (myColor == DieColor.Green)
        {
            m_SpriteRenderer.sprite = m_GreenSprite;
        }
        else if (myColor == DieColor.Red)
        {
            m_SpriteRenderer.sprite = m_RedSprite;
        }
        else if (myColor == DieColor.Yellow)
        {
            m_SpriteRenderer.sprite = m_YellowSprite;
        }
    }
}
