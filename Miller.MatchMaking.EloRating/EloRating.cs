namespace Miller.MatchMaking.EloRating;

public struct EloRating
{
    private readonly int _value;

    public EloRating(int value)
    {
        _value = value;
    }

    public static implicit operator int(EloRating rating)
    {
        return rating._value;
    }

    public static explicit operator EloRating(int value)
    {
        return new EloRating(value);
    }
    
    public static EloRating operator -(EloRating a, EloRating b)
    {
        int intA = a;
        int intB = b;
        return (EloRating)(intA - intB);
    }

    public static EloRating operator +(EloRating a, EloRating b)
    {
        int intA = a;
        int intB = b;
        return (EloRating)(intA + intB);
    }

    public override string ToString()
    {
        return _value.ToString();
    }

    /// <summary>
    /// Returns the probability of the player in the second position winning.
    /// </summary>
    /// <param name="playerARating"></param>
    /// <param name="playerBRating"></param>
    /// <returns></returns>
    public static double CalculateWinProbability(EloRating playerARating, EloRating playerBRating)
    {
        var exponent = (playerBRating - playerARating) / 400;
        var denominator = 1 + Math.Pow(10, 1.0f * exponent);
        var playerAExpectedScore = 1 / denominator;
        return Math.Round(playerAExpectedScore, 4);
    }
    
    public static EloRating CalculateEloExchanged(EloRating playerARating, EloRating playerBRating, bool playerAWon = true, int kValue = 30)
    {
        var probPlayerB = CalculateWinProbability(playerARating, playerBRating);

        var ra = 0.0d;
        if (playerAWon)
        {
            ra += kValue * (1 - probPlayerB);
        }
        else
        {
            ra += kValue * (0 - probPlayerB);
        }

        return (EloRating)Math.Round(ra, 0);
    }
}