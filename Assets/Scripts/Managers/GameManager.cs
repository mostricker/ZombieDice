using Assets.Scripts.Die;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject m_dieReference;

    // Global
    public List<Die> m_Cup = new List<Die>();
    public Dictionary<string, int> m_Players;

    // Current turn stuff
    public int m_Turn = 0;
    public List<Die> m_Hand = new List<Die>(); // all 3, or footprints
    public List<Die> m_Aside = new List<Die>(); // brains, shotguns
    public int m_Brains;

    // Use this for initialization
    void Start()
    {
        StartTurn();
    }

    void StartTurn()
    {
        // Reset dice cup to starting state
        m_Cup.Clear();
        AddDiceToCup(6, DieColor.Green);
        AddDiceToCup(4, DieColor.Yellow);
        AddDiceToCup(3, DieColor.Red);

        // Reset current player things
        m_Hand.Clear();
        m_Aside.Clear();

        // Draw dice to begin turn
        GetDice();
    }

    void AddDiceToCup(int count, DieColor color)
    {
        for (int i = 0; i < count; i++)
        {
            m_Cup.Add(new Die(color));
        }
    }

    // How many footprint dice does the current player have?
    int NumFootPrints()
    {
        return m_Hand.Select(die => die.m_Type == DieType.Footprints).ToArray().Count();
    }

    // Draws up to 3 dice from the cup
    void GetDice()
    {
        // don't draw more than 3 dice
        if (m_Hand.Count >= 3)
        {
            return;
        }

        // handle empty cup issue, replace brains
        // ...

        // replace brains and shotguns
        int numDiceToDraw = 3 - NumFootPrints();
        if (numDiceToDraw == 0)
        {
            return;
        }

        // shuffle cup
        int cupCount = m_Cup.Count;
        m_Cup = m_Cup.OrderBy(item => Random.Range(0, cupCount)).ToList();

        // fill hand with up to 3 dice
        for (int i = 0; i < numDiceToDraw; i++)
        {
            m_Hand.Add(m_Cup[0]);
            m_Cup.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("roll_dice"))
        {
            GetDice();
            DebugLogHand();

            RollDice();
            DebugLogHand();

            PutDiceAside();
            DebugLogHand();
        }
    }

    void DebugLogHand()
    {
        Debug.Log("Hand:");
        m_Hand.ForEach(die => Debug.Log(die.ToString()));
    }

    void RollDice()
    {
        m_Hand.ForEach(die => die.Roll());

        // randomize die type
        //for (int i = 0; i < m_Hand.Count; i++)
        //{
        //    m_Hand[i].Roll();
        //}
    }

    void PutDiceAside()
    {
        // copy shotguns and brains out of the hand...
        for (int i = 0; i < m_Hand.Count; i++)
        {
            if (m_Hand[i].m_Type == DieType.Shotgun || m_Hand[i].m_Type == DieType.Brain)
            {
                m_Aside.Add(m_Hand[i]);
            }
        }

        // then remove them
        m_Hand.RemoveAll(die => die.m_Type == DieType.Shotgun || die.m_Type == DieType.Brain);
    }
}
