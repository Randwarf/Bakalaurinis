using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ElementalEffectiveness
{
    private static float normal = 1.0f;
    private static float weak = 0.5f;
    private static float effective = 1.5f;
    private static float[,] effectiveness =
    {
        // Has to be same order as the Element enum
        // Normal, Fire, Water, Ice
        {normal, normal, normal, normal}, // Normal
        {normal,  weak, effective, weak}, // Fire
        {normal, weak, weak, effective }, // Water
        {normal, effective, weak, weak }, // Ice
    };

    public static float GetEffectiveness(Element attacker, Element defender)
    {
        int attackerIndex = (int)attacker;
        int defenderIndex = (int)defender;

        if ( attackerIndex < 0 || attackerIndex >= effectiveness.GetLength(0) ||
            defenderIndex < 0 || defenderIndex >= effectiveness.GetLength(1) ) 
        {
            return normal;
        }

        return effectiveness[attackerIndex, defenderIndex];
    }
}
