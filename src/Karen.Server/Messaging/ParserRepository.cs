using System.Collections.Concurrent;

namespace Karen.Server.Messaging;

public class ParserRepository {
    private readonly ILogger<ParserRepository> logger;

    private readonly ConcurrentDictionary<int, IParser> parsers;

    public ParserRepository( ILogger<ParserRepository> logger ) {
        this.logger = logger;
        this.parsers = [];
    }

    public void RegisterParser( short header, IParser parser ) {
        this.logger.LogInformation( $"Adding parser for {header}" );
        if( !this.parsers.TryAdd( header, parser ) )
            throw new Exception( $"Failed to add parser for {header}" );
    }

    public IParser? GetParser( short header ) {
        return this.parsers.TryGetValue( header, out IParser? parser ) ? parser : null;
    }
}
