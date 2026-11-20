using System;
using System.Collections.Generic;
using UnityEngine;
using static CardLibrary;

public static class CardFactory
{
    private static Dictionary<string, Func<Card>> cards =
        new Dictionary<string, Func<Card>>()
        {
            
        #region colorless
        {"shield", () => new Shield() },
        #endregion
        #region Lightning
        {"charge", () => new Charge() },
        {"lightningshot", () => new LightningShot() },
        {"chainlightning", () => new ChainLightning() },
        {"lightningbolt", () => new LightningBolt() },
       #endregion
        #region ice
        {"freeze", () => new Freeze() },
        {"icebolt", () => new IceBolt() },
        #endregion
        #region fire
        {"burn", () => new Burn() },
        {"firebolt", () => new FireBolt() },
        #endregion
        #region curse
        {"blank", () => new Blank() }
        #endregion
        };

    public static Card Create(string id)
    {
        //return a new instance of the card with the given id
        return cards[id]();
    }
}
