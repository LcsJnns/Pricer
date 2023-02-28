namespace Deserialization
{
    public class Call
    {
        public string contractSymbol { get; set; }
        public double strike { get; set; }
        public string currency { get; set; }
        public double lastPrice { get; set; }
        public double change { get; set; }
        public double percentChange { get; set; }
        public double volume { get; set; }
        public double opendoubleerest { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public string contractSize { get; set; }
        public double expiration { get; set; }
        public double lastTradeDate { get; set; }
        public double impliedVolatility { get; set; }
        public bool doubleheMoney { get; set; }
    }

    public class Option
    {
        public double expirationDate { get; set; }
        public bool hasMiniOptions { get; set; }
        public List<Call> calls { get; set; }
        public List<Put> puts { get; set; }
    }

    public class OptionChain
    {
        public List<Result> result { get; set; }
        public object error { get; set; }
    }

    public class Put
    {
        public string contractSymbol { get; set; }
        public double strike { get; set; }
        public string currency { get; set; }
        public double lastPrice { get; set; }
        public double change { get; set; }
        public double percentChange { get; set; }
        public double volume { get; set; }
        public double opendoubleerest { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public string contractSize { get; set; }
        public double expiration { get; set; }
        public double lastTradeDate { get; set; }
        public double impliedVolatility { get; set; }
        public bool doubleheMoney { get; set; }
    }

    public class Quote
    {
        public string language { get; set; }
        public string region { get; set; }
        public string quoteType { get; set; }
        public string typeDisp { get; set; }
        public string quoteSourceName { get; set; }
        public bool triggerable { get; set; }
        public string customPriceAlertConfidence { get; set; }
        public string currency { get; set; }
        public double earningsTimestamp { get; set; }
        public double earningsTimestampStart { get; set; }
        public double earningsTimestampEnd { get; set; }
        public double trailingAnnualDividendRate { get; set; }
        public double trailingPE { get; set; }
        public double trailingAnnualDividendYield { get; set; }
        public double epsTrailingTwelveMonths { get; set; }
        public double epsForward { get; set; }
        public double epsCurrentYear { get; set; }
        public double priceEpsCurrentYear { get; set; }
        public long sharesOutstanding { get; set; }
        public double bookValue { get; set; }
        public double fiftyDayAverage { get; set; }
        public double fiftyDayAverageChange { get; set; }
        public double fiftyDayAverageChangePercent { get; set; }
        public double twoHundredDayAverage { get; set; }
        public double twoHundredDayAverageChange { get; set; }
        public double twoHundredDayAverageChangePercent { get; set; }
        public long marketCap { get; set; }
        public double forwardPE { get; set; }
        public double priceToBook { get; set; }
        public double sourcedoubleerval { get; set; }
        public double exchangeDataDelayedBy { get; set; }
        public string averageAnalystRating { get; set; }
        public bool tradeable { get; set; }
        public bool cryptoTradeable { get; set; }
        public string exchange { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public string messageBoardId { get; set; }
        public string exchangeTimezoneName { get; set; }
        public string exchangeTimezoneShortName { get; set; }
        public double gmtOffSetMilliseconds { get; set; }
        public string market { get; set; }
        public bool esgPopulated { get; set; }
        public string marketState { get; set; }
        public double regularMarketChangePercent { get; set; }
        public double regularMarketPrice { get; set; }
        public double preMarketChangePercent { get; set; }
        public double preMarketTime { get; set; }
        public double preMarketPrice { get; set; }
        public double regularMarketChange { get; set; }
        public double regularMarketTime { get; set; }
        public double regularMarketDayHigh { get; set; }
        public string regularMarketDayRange { get; set; }
        public double regularMarketDayLow { get; set; }
        public double regularMarketVolume { get; set; }
        public double regularMarketPreviousClose { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public double bidSize { get; set; }
        public double askSize { get; set; }
        public string fullExchangeName { get; set; }
        public string financialCurrency { get; set; }
        public double regularMarketOpen { get; set; }
        public double averageDailyVolume3Month { get; set; }
        public double averageDailyVolume10Day { get; set; }
        public double fiftyTwoWeekLowChange { get; set; }
        public double fiftyTwoWeekLowChangePercent { get; set; }
        public string fiftyTwoWeekRange { get; set; }
        public double fiftyTwoWeekHighChange { get; set; }
        public double fiftyTwoWeekHighChangePercent { get; set; }
        public double fiftyTwoWeekLow { get; set; }
        public double fiftyTwoWeekHigh { get; set; }
        public double dividendDate { get; set; }
        public long firstTradeDateMilliseconds { get; set; }
        public double priceHdouble { get; set; }
        public double preMarketChange { get; set; }
        public string displayName { get; set; }
        public string symbol { get; set; }
    }

    public class Result
    {
        public string underlyingSymbol { get; set; }
        public List<double> expirationDates { get; set; }
        public List<double> strikes { get; set; }
        public bool hasMiniOptions { get; set; }
        public Quote quote { get; set; }
        public List<Option> options { get; set; }
    }

    public class Root
    {
        public OptionChain optionChain { get; set; }
    }
}