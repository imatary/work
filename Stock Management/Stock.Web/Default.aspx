<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Stock.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-8">
        <div class="container">
            <div class="row" style="margin-bottom: 20px">
                <%--<div class="form-group col-xs-12 ">
                <asp:TextBox runat="server" ID="txtBarcode" class="form-control text-center" Font-Bold="True" placeholder="Barcode" />
                <p class="help-block text-danger"></p>
            </div>--%>
                <div class="center-block">
                    <a href="Imports.aspx" class="btn btn-info btn-lg col-xs-12">Nhập Kho</a>
                </div>
            </div>
            <div class="row">
                <div class="center-block">
                    <a href="Exports.aspx" class="btn btn-info btn-lg col-xs-12">Xuất Kho</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
