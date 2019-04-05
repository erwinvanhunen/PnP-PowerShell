﻿using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Set, "PnPHomeSite")]
    [CmdletHelp("Sets the home site for your tenant",
     SupportedPlatform = CmdletSupportedPlatform.Online,
     Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
     Code = @"PS:> Set-PnPHomeSite -Url https://yourtenant.sharepoint.com/sites/myhome",
     Remarks = @"Sets the home site to the provided site collection url", SortOrder = 1)]
    public class SetHomeSite : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The url of the site to set as the home site")]
        public string Url;

        protected override void ExecuteCmdlet()
        {
            Tenant.SetSPHSite(Url);
            ClientContext.ExecuteQueryRetry();
        }
    }
}