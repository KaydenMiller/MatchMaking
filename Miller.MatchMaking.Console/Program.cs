using Miller.MatchMaking.EloRating;

var eloA = new EloRating(1400);
var eloB = new EloRating(1000);

var eloDelta = EloRating.CalculateEloExchanged(eloA, eloB);

Console.WriteLine($"Player A won: {eloDelta}; Player B lost: {eloDelta}");