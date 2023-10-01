﻿namespace Poker.HandRankClassification
{
    public interface IHandRankHandler
    {
        IHandRankHandler SetNext(IHandRankHandler handler);

        HandResult Handle(List<Card> cards);
    }
}
