﻿<%@ Page Language="C#" CodeBehind="Redirect.aspx.cs" Inherits="Playground.WebForms.RedirectPage" %>

<%@ Register Src="~/Controls/RedirectControl.ascx" TagPrefix="uc" TagName="Redirect" %>
<asp:content contentplaceholderid="content" runat="server">
    <h1>Redirect From Presenter Demo</h1>
    <uc:Redirect runat="server" />
</asp:content>
