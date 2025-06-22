namespace Karen.Common.Dto;
public class PlayerDetails {
    public int Id { get; init; }
    public required string Username { get; init; }
    public required int Credits { get; set; }
    public required string Figure { get; set; }
    public required bool Sex { get; set; } // 1 male 0 female
    public required string Mission { get; set; }
    public required int Tickets { get; set; }
    public required string PoolFigure { get; set; }
    public required int Film { get; set; }
    public required bool ReceiveNews { get; set; }
}
