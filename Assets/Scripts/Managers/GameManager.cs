using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Prefab die to clone
    public GameObject m_diePrefab;

    // Player name => Player score
    public Dictionary<string, int> m_Players;

    // Whose turn is it
    public int m_Turn = 0;

    // Cup with all (or remaining) dice
    public List<Die> m_Cup = new List<Die>();

    // Dice in hand. This can be dice of all 3 types, or just footprints
    public List<Die> m_Hand = new List<Die>();

    // Dice set aside. This is only brains and shotguns.
    public List<Die> m_Aside = new List<Die>();

    // Potential score of the current turn. This is needed because brain dice may be recycled.
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
        m_Brains = 0;

        // Draw dice to begin turn
        GetDice();
    }

    void NextTurn()
    {
        m_Turn = (m_Turn + 1) % m_Players.Count;
        StartTurn();
    }

    void AddDiceToCup(int count, DieColor color)
    {
        for (int i = 0; i < count; i++)
        {
            // create game object
            var obj = Instantiate(m_diePrefab);
            var die = (Die)obj.GetComponent<Die>();
            die.setColor(color);

            var x = 0;
            if (die.IsRed)
            {
                x = 1;
            }
            else if (die.IsYellow)
            {
                x = 2;
            }
            obj.transform.position = new Vector3(x, i, 0.0f);
            die.SetDieInstance(obj);

            // add newly created die (and associated game object) to the cup
            m_Cup.Add(die);
        }
    }

    // How many footprint dice does the current player have?
    int NumFootPrints()
    {
        return m_Hand.Select(die => die.IsFootprints).ToArray().Count();
    }

    // Draws up to 3 dice from the cup
    void GetDice()
    {
        // is our hand already full?
        if (m_Hand.Count >= 3)
        {
            return;
        }

        // if now, how many dice do we need to draw?
        int numDiceToDraw = 3 - NumFootPrints();
        if (numDiceToDraw == 0)
        {
            return;
        }

        // does the cup have enough dice for us to draw?
        if (m_Cup.Count < numDiceToDraw)
        {
            PlaceBrainRollsIntoCup();
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

    void PlaceBrainRollsIntoCup()
    {
        for (int i = 0; i < m_Aside.Count; i++)
        {
            if (m_Aside[i].IsBrain)
            {
                m_Brains += 1;
                m_Cup.Add(m_Aside[i]);
            }
        }

        m_Aside.RemoveAll(die => die.IsBrain);
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
        for (int i = 0; i < m_Hand.Count; i++)
        {
            m_Hand[i].Roll();
        }
    }

    void PutDiceAside()
    {
        // copy shotguns and brains out of the hand...
        for (int i = 0; i < m_Hand.Count; i++)
        {
            if (m_Hand[i].IsShotgun || m_Hand[i].IsBrain)
            {
                m_Aside.Add(m_Hand[i]);
            }
        }

        // then remove them
        m_Hand.RemoveAll(die => die.IsShotgun || die.IsBrain);
    }
}
