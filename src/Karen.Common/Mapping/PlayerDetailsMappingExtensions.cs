using Karen.Common.Dto;
using Karen.Common.Storage.Entities;

namespace Karen.Common.Mapping;
public static class PlayerDetailsMappingExtensions {
    public static PlayerDetails MapToDto( this PlayerDetailsEntity entity ) {
        return new() {
            Id = entity.Id,
            Username = entity.Username,
            Credits = entity.Credits,
            Figure = entity.Figure,
            Sex = entity.Sex,
            Mission = entity.Mission,
            Tickets = entity.Tickets,
            PoolFigure = entity.PoolFigure,
            Film = entity.Film,
            ReceiveNews = entity.ReceiveNews
        };
    }
}
