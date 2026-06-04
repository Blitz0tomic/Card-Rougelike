using System;
using System.Collections.Generic;
using UnityEngine;
using static CardLibrary;

public static class CardFactory
{
    private static Dictionary<string, Func<Card>> cards =
        new Dictionary<string, Func<Card>>()
    {
        { "charge", () => new Charge() },
        { "freeze", () => new Freeze() },
        { "icebolt", () => new IceBolt() },
        { "lightningstrike", () => new LightningStrike() },
        {"chainlightning", () => new ChainLightning() },
        {"lightningbolt", () => new LightningBolt() },
        {"blank", () => new Card("Blank", RarityType.Common, EffectType.Nothing, ElementType.None, false) }
    };

    public static Card Create(string id)
    {
        return cards[id]();
    }
}
