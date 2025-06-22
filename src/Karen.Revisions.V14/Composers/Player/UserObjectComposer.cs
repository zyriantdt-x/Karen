using Karen.Common.Dto;

namespace Karen.Revisions.V14.Composers.Player;
public class UserObjectComposer : ComposerBase {
    public override short Header => 5;

    public int Id { get; init; }
    public string Username { get; init; }
    public string Figure { get; init; }
    public string Sex { get; init; } // 1 male 0 female
    public string Mission { get; init; }
    public int Tickets { get; init; }
    public string PoolFigure { get; init; }
    public int Film { get; init; }
    public bool ReceiveNews { get; init; }

    public UserObjectComposer( PlayerDetails dto ) {
        this.Id = dto.Id;
        this.Username = dto.Username;
        this.Figure = dto.Figure;
        this.Sex = dto.Sex ? "M" : "F";
        this.Mission = dto.Mission;
        this.Tickets = dto.Tickets;
        this.PoolFigure = dto.PoolFigure;
        this.ReceiveNews = dto.ReceiveNews;
    }

    protected override void Compose() {
        this.Write( this.Id.ToString()! );
        this.Write( this.Username );
        this.Write( this.Figure );
        this.Write( this.Sex );
        this.Write( this.Mission );
        this.Write( this.Tickets );
        this.Write( this.PoolFigure );
        this.Write( this.Film );
        this.Write( this.ReceiveNews );
    }
}
