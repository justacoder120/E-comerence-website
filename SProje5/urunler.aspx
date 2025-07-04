<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="urunler.aspx.cs" Inherits="SProje5.urunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .filter-container {
            margin: 20px;
            padding: 10px;
            border: 4px solid #c1c1c1;
            border-radius: 10px;
            background-color: #eaeaea;
        }

        .filter-label {
            margin-right: 10px;
        }

        .filter-dropdown {
            margin-right: 20px;
            border-radius: 10px;
        }

        .apply-button {
            border-radius: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="filter-container">
        <label class="filter-label" for="drpKategori">Kategori:</label>
        <asp:DropDownList ID="drpKategori" runat="server" CssClass="filter-dropdown"></asp:DropDownList>

        <label class="filter-label" for="drpMarka">Marka:</label>
        <asp:DropDownList ID="drpMarka" runat="server" CssClass="filter-dropdown"></asp:DropDownList>

        <label class="filter-label" for="drpRenk">Renk:</label>
        <asp:DropDownList ID="drpRenk" runat="server" CssClass="filter-dropdown"></asp:DropDownList>

        <label class="filter-label" for="drpSiralama">Sırala:</label>
        <asp:DropDownList ID="drpSiralama" runat="server" CssClass="filter-dropdown">
            <asp:ListItem Text="Varsayılan" Value="0" />
            <asp:ListItem Text="Artan Fiyat" Value="1" />
            <asp:ListItem Text="Azalan Fiyat" Value="2" />
        </asp:DropDownList>

        <asp:Button class="btn btn-outline-dark apply-button" ID="btnUygula" runat="server" Text="Uygula" OnClick="btnUygula_Click" />
    </div>


    <div class="row m-3">
        <asp:Repeater ID="AyakkabıKartı" runat="server" OnItemDataBound="AyakkabıKartı_ItemDataBound" OnItemCommand="AyakkabıKartı_ItemCommand">
            <ItemTemplate>
                <div class="col-3 mt-3">
                    <div class="card">
                        <div class="card-header text-center">
                            <a href='<%# ResolveUrl("Detay.aspx?AyakkabıID=" + Eval("AyakkabıID")) %>'>
                                <img style="height: auto; width: 150px; display: block; margin: 0 auto;" src='<%# Eval("Resim", ResolveUrl("Resimler/{0}")) %>' />
                            </a>
                        </div>
                        <div class="card-body">
                            <p style="font-size: 20px; font-weight: 500; overflow: hidden; text-overflow: ellipsis; display: -webkit-box; -webkit-line-clamp: 2; -webkit-box-orient: vertical; height: 2.8em;" class="card-title">
                                <%# Eval("AyakkabıAdı") %>
                            </p>
                            <p style="font-size: 25px; font-weight: 700" class="card-text">
                                <%# Eval("Fiyat", "{0}₺") %>
                            </p>
                        </div>
                        <asp:Panel runat="server" ID="adminButonlari" class="card-footer">
                            <a href='<%# ResolveUrl("ayakkabıGuncelle.aspx?LinkAyakkabıID=" + Eval("AyakkabıID")) %>' class="btn btn-outline-dark">Güncelle</a>
                            <asp:LinkButton runat="server" Text="Sil" class="btn btn-outline-danger" CommandName="AyakkabıSil" CommandArgument='<%# Eval("AyakkabıID") %>' OnClientClick="return confirm('Bu ayakkabıları listeden silmek istediğinizden emin misiniz?')" />
                        </asp:Panel>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
