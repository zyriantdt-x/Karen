namespace Karen.Common.Messages.Outgoing.Handshake;
public class SessionParametersMessage {
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