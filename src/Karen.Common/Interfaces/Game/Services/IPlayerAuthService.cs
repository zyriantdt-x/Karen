namespace Karen.Common.Interfaces.Game.Services;
public interface IPlayerAuthService {
    Task<bool> TryLoginAsync( IKarenClient client, string username, string password );
}
