﻿<%@ Control Language="C#" CodeBehind="AsyncApmControl.ascx.cs" Inherits="Playground.Controls.AsyncApmControl" %>
<div class="async-messages">
 <asp:Repeater runat="server" DataSource="<%# Model.Messages %>">
  <HeaderTemplate>
   <ol>
  </HeaderTemplate>
  <ItemTemplate>
   <li><%# Container.DataItem %></li>
  </ItemTemplate>
  <FooterTemplate>
   </ol>
  </FooterTemplate>
 </asp:Repeater>
</div>
