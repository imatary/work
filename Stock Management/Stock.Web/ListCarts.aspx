<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCarts.aspx.cs" Inherits="Stock.Web.ListCarts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="611px">
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="Tên" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
        </Columns>
    </asp:GridView>
    
</asp:Content>
