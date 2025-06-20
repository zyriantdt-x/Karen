using System.Collections.Concurrent;

namespace Karen.Server.Messaging;

public class HandlerRepository {
    private readonly ILogger<HandlerRepository> logger;

    private readonly ConcurrentDictionary<int, Type> handlers;
    private readonly IServiceProvider sp;

    public HandlerRepository( ILogger<HandlerRepository> logger, IServiceProvider sp ) {
        this.logger = logger;

        this.handlers = [];
        this.sp = sp;
    }

    public void RegisterHandler( short header, Type handler ) {
        this.logger.LogInformation( $"Adding handler for {header}" );
        if( !this.handlers.TryAdd( header, handler ) )
            throw new Exception( $"Failed to add handler for {header}" );
    }

    public IHandler? CreateHandler( short header ) { // i'm not sure if we need to create a handler each time or if a single one will suffice... we will see
        //Type handler_type = this.handlers[ header ];
        if(!this.handlers.TryGetValue( header, out Type handler_type ) ) {
            this.logger.LogWarning( $"No handler found for {header}" );
            return null;
        }

        return handler_type.IsAssignableFrom( typeof( IHandler ) )
               ? ( IHandler? )this.sp.GetRequiredService( handler_type )
               : throw new Exception( $"A handler was found for {header}, but it wasn't assignable to IHandler" ); 
    }
}
