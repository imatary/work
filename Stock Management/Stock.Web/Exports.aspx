<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exports.aspx.cs" Inherits="Stock.Web.Exports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanelIssue">
        <ContentTemplate>
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                <div class="row">
                    <div class="form-group col-xs-12 ">
                        <asp:TextBox runat="server" ID="txtBarcode" class="form-control text-center" Font-Bold="True" placeholder="Barcode" />
                        <p id="barcode" runat="server" class="help-block text-danger"></p>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-xs-12 ">
                        <asp:TextBox runat="server" ID="txtQuantity" class="form-control" Font-Bold="True" placeholder="Quantity" />
                        <p id="quantity" runat="server" class="help-block text-danger"></p>
                    </div>
                </div>
                <div class="row ">
                    <div class="col-xs-12">
                        <p id="messageError" runat="server" class="help-block text-danger pull-left" style="font-weight: bold; color: red;"></p><br/>
                        <p id="countOrder" runat="server" class="help-block text-danger pull-left"></p>
                    </div>
                    <div class="col-xs-12 ">
                        <div class="row">
                            <div class="col-xs-4">
                                <asp:Button runat="server" ID="btnAddToCart" CssClass="btn btn-sm btn-success" OnClick="btnAddToCart_OnClick" Text="Add to..." />
                            </div>
                            <div class="col-xs-4">
                                <asp:Button runat="server" ID="btnSave" OnClick="btnSave_OnClick" CssClass="btn btn-sm btn-info" Text="Lập hóa đơn" />
                            </div>
                            <%--<div class="col-xs-4">
                                <a href="ListCarts.aspx" class="btn btn-sm btn-info hide">Xem danh sách</a>
                            </div>  --%>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:GridView ID="GridView1" runat="server" BorderStyle="None" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="ProductName" HeaderText="Tên" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:BoundField DataField="Price" HeaderText="Price" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="updateProcessIssue" AssociatedUpdatePanelID="updatePanelIssue">
        <ProgressTemplate>
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                <div class="row">
                    <div class="col-xs-12">
                        <button class="btn btn-lg btn-warning">
                            <span class="glyphicon glyphicon-refresh glyphicon-refresh-animate"></span>&nbsp;Loading...
                        </button>
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
