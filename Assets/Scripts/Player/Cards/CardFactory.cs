using System;
using System.Collections.Generic;
using UnityEngine;
using static CardLibrary;

public static class CardFactory
{
    private static Dictionary<string, Func<Card>> cards =
        new Dictionary<string, Func<Card>>()
        {
        {"shield", () => new Shield() },
        {"charge", () => new Charge() },
        {"lightningshot", () => new LightningShot() },
        {"chainlightning", () => new ChainLightning() },
        {"lightningbolt", () => new LightningBolt() },
        {"freeze", () => new Freeze() },
        {"icebolt", () => new IceBolt() },
        {"burn", () => new Burn() },
        {"firebolt", () => new FireBolt() },
        {"blank", () => new Blank() }
        };

    public static Card Create(string id)
    {
        //return a new instance of the card with the given id
        return cards[id]();
    }
}
