using Assets.Scripts.Die;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject m_dieReference;

    // Global
    public List<Die> m_Cup;
    public Dictionary<string, int> m_Players;

    // Current turn stuff
    public int m_Turn = 0;
    public List<Die> m_Hand;
    public List<Die> m_Aside;
    public int m_Brains;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Started gamemanager!");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("roll_dice"))
        {
            RollDice();
        }
    }

    void RollDice()
    {
        
    }
}
