﻿<%@ Page Language="C#" CodeBehind="HelloWorld.aspx.cs" Inherits="Playground.HelloWorldPage" %>

<%@ Register Src="~/Controls/HelloWorldControl.ascx" TagPrefix="uc" TagName="HelloWorld" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 <h2>Hello World</h2>
 <uc:HelloWorld runat="server" />
</asp:Content>
