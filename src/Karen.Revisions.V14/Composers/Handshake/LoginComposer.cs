using Karen.Common.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen.Revisions.V14.Composers.Handshake;
public class LoginComposer : ComposerBase {
    public override short Header => 3;

    protected override void Compose() {}
}
