using System.Collections.Concurrent;
using System.Reflection;

namespace Karen.Server.Messaging;

public class HandlerRepository {
    private readonly ILogger<HandlerRepository> logger;

    private readonly ConcurrentDictionary<int, IHandler> handlers; // i'd like these to be transient but we're not there yet
    private readonly IServiceProvider sp;

    public HandlerRepository( ILogger<HandlerRepository> logger, IServiceProvider sp ) {
        this.logger = logger;

        this.handlers = [];
        this.sp = sp;

        this.RegisterHandlers();
    }

    private void RegisterHandlers() {
        foreach( IHandler handler in this.sp.GetServices<IHandler>() ) {
            this.RegisterHandler( handler.Header, handler );
        }
    }

    public void RegisterHandler( short header, IHandler handler ) {
        this.logger.LogInformation( $"Adding handler for {header}" );
        if( !this.handlers.TryAdd( header, handler ) )
            throw new Exception( $"Failed to add handler for {header}" );
    }

    public IHandler? GetHandler( short header ) { // one for now... shame they're not transient
        //Type handler_type = this.handlers[ header ];
        if(!this.handlers.TryGetValue( header, out IHandler? handler ) ) {
            this.logger.LogWarning( $"No handler found for {header}" );
            return null;
        }

        return handler;
    }
}
