using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen.Revisions.V14.Composers.Handshake;
public class SessionParametersComposer : ComposerBase {
    public override short Header => 257;

    public Dictionary<SessionParameters, string> Parameters { get; set; } = new() {
            { SessionParameters.VOUCHER_ENABLED, "1" }, // todo: load from db
            { SessionParameters.REGISTER_REQUIRE_PARENT_EMAIL, "0" },
            { SessionParameters.REGISTER_SEND_PARENT_EMAIL, "0" },
            { SessionParameters.ALLOW_DIRECT_MAIL, "0" },
            { SessionParameters.DATE_FORMAT, "dd-MM-yyyy" },
            { SessionParameters.PARTNER_INTEGRATION_ENABLED, "0" },
            { SessionParameters.ALLOW_PROFILE_EDITING, "1" }, // todo: load from db
            { SessionParameters.TRACKING_HEADER, "" },
            { SessionParameters.TUTORIAL_ENABLED, "0" },
        };

    protected override async Task ComposeAsync() {
        await this.Write( this.Parameters.Count );

        foreach( KeyValuePair<SessionParameters, string> parameter in this.Parameters ) {
            SessionParameters key = parameter.Key;
            string value = parameter.Value;

            await this.Write( ( int )key );

            if( !String.IsNullOrWhiteSpace( value ) && Int32.TryParse( value, out int value_as_int ) )
                await this.Write( value_as_int );
            else
                await this.Write( value );
        }
    }
}

public enum SessionParameters {
    VOUCHER_ENABLED = 1,
    REGISTER_REQUIRE_PARENT_EMAIL = 2,
    REGISTER_SEND_PARENT_EMAIL = 3,
    ALLOW_DIRECT_MAIL = 4,
    DATE_FORMAT = 5,
    PARTNER_INTEGRATION_ENABLED = 6,
    ALLOW_PROFILE_EDITING = 7,
    TRACKING_HEADER = 8,
    TUTORIAL_ENABLED = 9
}