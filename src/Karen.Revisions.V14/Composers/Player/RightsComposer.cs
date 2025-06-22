namespace Karen.Revisions.V14.Composers.Player;
public class RightsComposer : ComposerBase {
    public override short Header => 2;

    protected override void Compose() {
        this.Write( "fuse_login" );
        this.Write( "fuse_trade" );
        this.Write( "fuse_buy_credits" );
        this.Write( "fuse_buy_credits_fuse_login" );
        this.Write( "fuse_room_queue_default" );
        this.Write( "fuse_mute" );
        this.Write( "fuse_kick" );
        this.Write( "fuse_receive_calls_for_help" );
        this.Write( "fuse_remove_photos" );
        this.Write( "fuse_remove_stickies" );
        this.Write( "fuse_mod" );
        this.Write( "fuse_moderator_access" );
        this.Write( "fuse_chat_log" );
        this.Write( "fuse_room_alert" );
        this.Write( "fuse_room_kick" );
        this.Write( "fuse_ignore_room_owner" );
        this.Write( "fuse_enter_full_rooms" );
        this.Write( "fuse_enter_locked_rooms" );
        this.Write( "fuse_see_all_roomowners" );
        this.Write( "fuse_search_users" );
        this.Write( "fuse_ban" );
        this.Write( "fuse_see_chat_log_link" );
        this.Write( "fuse_cancel_roomevent" );
        this.Write( "fuse_administrator_access" );
        this.Write( "fuse_any_room_controller" );
        this.Write( "fuse_pick_up_any_furni" );
        this.Write( "fuse_see_flat_ids" );
        this.Write( "fuse_credits" );
        this.Write( "fuse_housekeeping_alert" );
        this.Write( "fuse_habbo_chooser" );
        this.Write( "fuse_performance_panel" );
    }
}
