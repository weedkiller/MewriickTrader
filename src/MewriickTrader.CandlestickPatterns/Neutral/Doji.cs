﻿using MewriickTrader.Core.Analysis;
using MewriickTrader.Core.Candle;

namespace MewriickTrader.CandlestickPatterns.Neutral
{
    public class Doji : ICandlePatternable
    {
        private decimal treshold;

        public Doji(decimal treshold = 0.1m)
        {
            this.treshold = treshold;
        }

        public CandlePatternMatch Match(IAnalyzableContext analyzableContext)
        {
            var candle = analyzableContext.CandleAtIndex;

            if (candle.Open == candle.Close)
            {
                return new CandlePatternMatch(true);
            }

            var isDoji = candle.RealBody() < treshold * candle.SizeFromHighToLow();

            return new CandlePatternMatch(isDoji);
        }
    }
}
