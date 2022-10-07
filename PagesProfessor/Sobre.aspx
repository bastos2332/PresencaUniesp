<%@ Page Title="" Language="C#" MasterPageFile="~/PagesProfessor/Default.Master" AutoEventWireup="true" CodeBehind="Sobre.aspx.cs" Inherits="PRESENCA_FACIL.PagesProfessor.Sobre" %>

<%@ Register Src="~/Wuc/wuc_sobre.ascx" TagPrefix="uc1" TagName="wuc_sobre" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <uc1:wuc_sobre runat="server" id="wuc_sobre" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
