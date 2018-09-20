using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Die
{
    public class Die
    {
        public DieColor m_Color; // Fixed
        public DieType m_Type;

        public Die(DieColor color)
        {
            this.m_Color = color;
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
}
