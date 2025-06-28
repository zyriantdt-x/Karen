using Karen.Common.Interfaces;
using Karen.Common.Messages.Outgoing.Player;
using Karen.Common.Protocol;

namespace Karen.Revisions.V14.Composers.Player;
public class RightsComposer : IComposer<RightsMessage> {
    public short Header => 2;

    public void Compose( ref PacketWriter writer, RightsMessage message ) {
        writer.Write( "fuse_login" );
        writer.Write( "fuse_trade" );
        writer.Write( "fuse_buy_credits" );
        writer.Write( "fuse_buy_credits_fuse_login" );
        writer.Write( "fuse_room_queue_default" );
        writer.Write( "fuse_mute" );
        writer.Write( "fuse_kick" );
        writer.Write( "fuse_receive_calls_for_help" );
        writer.Write( "fuse_remove_photos" );
        writer.Write( "fuse_remove_stickies" );
        writer.Write( "fuse_mod" );
        writer.Write( "fuse_moderator_access" );
        writer.Write( "fuse_chat_log" );
        writer.Write( "fuse_room_alert" );
        writer.Write( "fuse_room_kick" );
        writer.Write( "fuse_ignore_room_owner" );
        writer.Write( "fuse_enter_full_rooms" );
        writer.Write( "fuse_enter_locked_rooms" );
        writer.Write( "fuse_see_all_roomowners" );
        writer.Write( "fuse_search_users" );
        writer.Write( "fuse_ban" );
        writer.Write( "fuse_see_chat_log_link" );
        writer.Write( "fuse_cancel_roomevent" );
        writer.Write( "fuse_administrator_access" );
        writer.Write( "fuse_any_room_controller" );
        writer.Write( "fuse_pick_up_any_furni" );
        writer.Write( "fuse_see_flat_ids" );
        writer.Write( "fuse_credits" );
        writer.Write( "fuse_housekeeping_alert" );
        writer.Write( "fuse_habbo_chooser" );
        writer.Write( "fuse_performance_panel" );
    }

    protected override void Compose() {
        
    }
}
