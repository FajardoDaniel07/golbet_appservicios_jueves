// GolBet.Entities/Match.cs 

using System.ComponentModel.DataAnnotations.Schema;

using GolBet.Entities.Common;

using GolBet.Entities.Enums;



namespace GolBet.Entities;



public class Match : AuditableEntity

{

    public DateTime Date { get; set; }



    public MatchStatus Status { get; set; } = MatchStatus.Scheduled;



    /// <summary>Null until the match finishes.</summary> 

    public int? HomeGoals { get; set; }

    public int? AwayGoals { get; set; }



    [Column(TypeName = "decimal(5,2)")]

    public decimal HomeOdds { get; set; }



    [Column(TypeName = "decimal(5,2)")]

    public decimal DrawOdds { get; set; }



    [Column(TypeName = "decimal(5,2)")]

    public decimal AwayOdds { get; set; }



    // Two foreign keys to the same table (Team) 

    public int HomeTeamId { get; set; }

    public Team HomeTeam { get; set; } = null!; // La relcion de esta PK con la tabal team



    public int AwayTeamId { get; set; }

    public Team AwayTeam { get; set; } = null!; // Declaracion explicita de que no es nuleable



    public ICollection<Bet> Bets { get; set; } = new List<Bet>();
    // Coleccion de cosas. En este caso corresponde a la relacion uno a muchos de match con bets, un partido tiene muchas apuestas y Icollection es un lista con muchas apuestas


}