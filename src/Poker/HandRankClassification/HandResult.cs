﻿namespace Poker.HandRankClassification
{
    public class HandResult : IComparable<HandResult>, IComparable
    {
        public HandResult(HandRank handRank, CardRank winningRank, CardRank kickerRank)
        {
            this.HandRank = handRank;
            this.WinningRank = winningRank;
            this.KickerRank = kickerRank;
        }

        public HandRank HandRank { get; set; }

        public CardRank WinningRank { get; set; }

        public CardRank KickerRank { get; set; }

        public int CompareTo(HandResult? other)
        {
            if (other == null)
            {
                return 1;
            }

            if (this.HandRank > other.HandRank)
            {
                return 1;
            }

            if (this.HandRank == other.HandRank && this.WinningRank > other.WinningRank)
            {
                return 1;
            }

            if (this.HandRank == other.HandRank && this.WinningRank == other.WinningRank && this.KickerRank > other.KickerRank)
            {
                return 1;
            }

            if (this.HandRank == other.HandRank && this.WinningRank == other.WinningRank && this.KickerRank == other.KickerRank)
            {
                return 0;
            }

            return -1;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var otherHandResult = obj as HandResult;

            if (otherHandResult == null)
            {
                return 1;
            }

            return this.CompareTo(otherHandResult);
        }

        public override string ToString()
        {
            return $"HandRank: {this.HandRank}, WinningRank: {this.WinningRank}, KickerRank: {this.KickerRank}";
        }
    }
}
