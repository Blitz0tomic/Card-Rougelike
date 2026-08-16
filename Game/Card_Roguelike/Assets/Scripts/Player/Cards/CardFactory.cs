using System;
using System.Collections.Generic;
using UnityEngine;
using static CardLibrary;

public static class CardFactory
{
    private static Dictionary<string, Func<Card>> cards =
        new Dictionary<string, Func<Card>>()
        {
        {"charge", () => new Charge() },
        {"freeze", () => new Freeze() },
        {"icebolt", () => new IceBolt() },
        {"lightningshot", () => new LightningShot() },
        {"chainlightning", () => new ChainLightning() },
        {"lightningbolt", () => new LightningBolt() },
        {"blank", () => new Blank() },
        {"shield", () => new Shield() }
        };

    public static Card Create(string id)
    {
        //return a new instance of the card with the given id
        return cards[id]();
    }
}
