using UnityEngine;

public static class CardLibrary
{
    public static Card CreateChainLightning()
        => new Card("Chain Lightning", RarityType.Rare);

    public static Card CreateLightningStrike()
        => new Card("Lightning Strike", RarityType.Common);

    public static Card CreateLightningBolt()
        => new Card("Lightning Bolt", RarityType.Legendary);
}


