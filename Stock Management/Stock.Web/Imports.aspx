<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Imports.aspx.cs" Inherits="Stock.Web.Imports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanelReceipt">
        <ContentTemplate>
            <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                <div class="row">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtBarcode" class="form-control text-center" Font-Bold="True" placeholder="Barcode" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtQuantity" class="form-control" Font-Bold="True" onkeypress="return isNumberKey(event)" placeholder="Quantity" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtPlan" class="form-control" Font-Bold="True" onkeypress="return isNumberKey(event)" placeholder="Plan" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12" runat="server" id="messagebox">
                    </div>
                    <div class="col-xs-12">
                        <div class="row">
                            <div class="col-xs-3">
                                <asp:LinkButton runat="server" ID="btnAddToCart" CssClass="btn btn-sm btn-info" OnClick="btnAddToCart_OnClick">
                                    <i class="glyphicon glyphicon-plus"></i>&nbsp;Add
                                </asp:LinkButton>
                            </div>
                            <div class="col-xs-3">
                                <asp:LinkButton runat="server" ID="btnSave" OnClick="btnSave_OnClick" CssClass="btn btn-sm btn-success">
                                    <i class="glyphicon glyphicon-export"></i>&nbsp;Nhập Kho
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
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
    <asp:UpdateProgress runat="server" ID="updateProcessReceipt" AssociatedUpdatePanelID="updatePanelReceipt">
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
