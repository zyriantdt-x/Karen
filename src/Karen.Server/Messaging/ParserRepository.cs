using System.Collections.Concurrent;

namespace Karen.Server.Messaging;

public class ParserRepository {
    private readonly ILogger<ParserRepository> logger;

    private readonly ConcurrentDictionary<int, IParser> parsers;
    private readonly IServiceProvider sp;

    public ParserRepository( ILogger<ParserRepository> logger, IServiceProvider sp ) {
        this.logger = logger;

        this.parsers = [];
        this.sp = sp;

        this.RegisterParsers();
    }

    private void RegisterParsers() {
        foreach( IParser parser in this.sp.GetServices<IParser>() ) {
            this.RegisterParser( parser.Header, parser );
        }
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
