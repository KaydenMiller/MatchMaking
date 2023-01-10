using FluentAssertions;

namespace Miller.MatchMaking.EloRating.Test.Unit;

public class EloTests
{
    [Theory]
    [InlineData(1000, 1000, 0.5d)]
    [InlineData(1400, 1000, 0.9091d)]
    [InlineData(1000, 1400, 0.0909d)]
    public void PlayerAShouldHaveCorrectWinProbability(int playerAElo, int playerBElo, double expectedProbability)
    {
        var eloA = (EloRating)playerAElo;
        var eloB = (EloRating)playerBElo;

        var actualProbability = EloRating.CalculateWinProbability(eloA, eloB);

        actualProbability.Should().Be(expectedProbability);
    }
    
    [Theory]
    [InlineData(1000, 1000, 15)]
    [InlineData(1400, 1000, 3)]
    [InlineData(1000, 1400, 27)]
    public void PlayerAShouldWinLessEloIfTheyAreFavoredVictor(int playerAElo, int playerBElo, int expectedEarnedElo)
    {
        var eloA = (EloRating)playerAElo;
        var eloB = (EloRating)playerBElo;

        var eloWon = EloRating.CalculateEloExchanged(eloA, eloB);
        
        ((int)eloWon).Should().Be(expectedEarnedElo);
    }
}