<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AramaSonuc.aspx.cs" Inherits="SProje5.AramaSonuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row m-3">
        <asp:Repeater ID="AyakkabıKartı" runat="server">
            <ItemTemplate>
                <div class="col-4 mt-4">
                    <div class="card">
                        <div class="card-body  cart-bg" style="border-radius: 15px">
                            <a href='<%# ResolveUrl("Detay.aspx?AyakkabıID=" + Eval("AyakkabıID")) %>'>
                                <img style="height: auto; width: 250px; display: block; margin: 0 auto;" src='<%# Eval("Resim", ResolveUrl("Resimler/{0}")) %>' />
                            </a>
                            <p style="font-size: 17px; font-weight: 500; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 2; -webkit-box-orient: vertical; height: 2.8em;" class="card-title">
                                <%# Eval("AyakkabıAdı") %>
                            </p>
                            <div class="row">
                                <div class="col">
                                    <strong>Marka:</strong>
                                </div>
                                <div class="col">
                                    <strong>Kategori:</strong>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <p><%# Eval("MMarka") %></p>
                                </div>
                                <div class="col">
                                    <p><%# Eval("KKategori") %></p>
                                </div>
                            </div>
                            <p style="font-size: 25px; font-weight: 700" class="card-text">
                                <%# Eval("Fiyat", " ${0}") %>
                            </p>
                            <a class="btn btn-dark w-100" href='<%# ResolveUrl("Detay.aspx?AyakkabıID=" + Eval("AyakkabıID")) %>'>Sepete Ekle</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
