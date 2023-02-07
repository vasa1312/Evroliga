<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="EuroLeague.Account.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Welcome!</h1>

    <asp:Panel ID="Panel1" runat="server">
        <h3>Standings</h3>

        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1"
            CssClass="table"></asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString=""
            SelectCommand="SELECT naziv,pobede,porazi FROM Tim ORDER BY pobede DESC"></asp:SqlDataSource>
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
        <h3>Top scorers</h3>

        <asp:GridView ID="GridView2" runat="server"
            CssClass="table" 
            DataSourceID="SqlDataSource2"></asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
            ConnectionString=""
            SelectCommand="SELECT imePrezime,tim,ppg FROM TopScorer ORDER BY ppg DESC"></asp:SqlDataSource>
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server">
        <h3>Insert Fantasy player</h3>

        <asp:Label ID="Label1" runat="server" Text="Full name:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="Label2" runat="server" Text="Fantasy points:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Insert player" CssClass="btn btn-primary" OnClick="Button1_Click" />
        <br />
        <br />

        <asp:Label ID="Label3" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
    </asp:Panel>

</asp:Content>
