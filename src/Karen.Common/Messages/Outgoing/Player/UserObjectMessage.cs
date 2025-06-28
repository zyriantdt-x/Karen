using Karen.Common.Dto;

namespace Karen.Common.Messages.Outgoing.Player;
public class UserObjectMessage {
    public int Id { get; init; }
    public string Username { get; init; }
    public string Figure { get; init; }
    public string Sex { get; init; } // 1 male 0 female
    public string Mission { get; init; }
    public int Tickets { get; init; }
    public string PoolFigure { get; init; }
    public int Film { get; init; }
    public bool ReceiveNews { get; init; }

    public UserObjectMessage( PlayerDetails dto ) {
        this.Id = dto.Id;
        this.Username = dto.Username;
        this.Figure = dto.Figure;
        this.Sex = dto.Sex ? "M" : "F";
        this.Mission = dto.Mission;
        this.Tickets = dto.Tickets;
        this.PoolFigure = dto.PoolFigure;
        this.ReceiveNews = dto.ReceiveNews;
    }
}
