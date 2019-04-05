﻿using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Get, "PnPHomeSite")]
    [CmdletHelp("Returns the home site url for your tenant",
     SupportedPlatform = CmdletSupportedPlatform.Online,
     Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
     Code = @"PS:> Get-PnPHomeSite",
     Remarks = @"Returns the home site url for your tenant", SortOrder = 1)]
    public class GetHomeSite : PnPAdminCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var results = Tenant.GetSPHSiteUrl();
            ClientContext.ExecuteQueryRetry();
            WriteObject(results.Value);
        }
    }
}