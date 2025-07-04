<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detay.aspx.cs" Inherits="SProje5.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .seyfam {
            margin: 60px auto;
            margin-top: 10px;
            padding: 25px;
        }

        .ayakkabi {
            display: flex;
            flex-wrap: wrap;
        }

        .resim {
            width: 600px;
            height: auto;
            border-radius: 4px;
        }

        .ayakkabi_detaylari {
            flex: 1;
            padding-left: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="seyfam">
        <div class="ayakkabi">
            <asp:Image class="resim" ID="AyakkabiResmi" runat="server"></asp:Image>
            <div class="ayakkabi_detaylari">
                <div class="col">
                    <asp:Label class="h4" ID="lblAyakkabiAdi" runat="server"></asp:Label>
                </div>
                <div class="col mb-3">
                    <asp:Label ID="lblAyakkabiMarkasi" runat="server"></asp:Label>
                </div>
                <div class="col mb-3">
                    <div class="row w-100">
                        <div class="col-4">
                            <asp:Label class="h2" ID="lblAyakkabiFiyat" runat="server"></asp:Label>
                        </div>
                        <div class="col-8">
                            <asp:Label class="h4 detaylar" ID="lblAyakkabiKategory" runat="server"></asp:Label>
                            <asp:Label class="h4 ms-4 detaylar" ID="lblAyakkabiRenk" runat="server"></asp:Label>
                            <asp:Label class="h4 ms-4 detaylar" ID="lblAyakkabiDeger" runat="server">4.9</asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col border rounded p-3" style="margin-top: 80px">
                    <div class="row">
                        <div class="col-3">
                            <p>Adet</p>
                        </div>
                        <div class="col-3">
                            <p>Beden</p>
                        </div>
                        <div class="col-6">
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <asp:TextBox TextMode="Number" class="w-100 form-control" ID="txtAdet" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-3">
                                <asp:DropDownList ID="drpBeden" runat="server" CssClass="filter-dropdown w-100 form-select">
                                    <asp:ListItem Text="35" Value="35" />
                                    <asp:ListItem Text="36" Value="36" />
                                    <asp:ListItem Text="37" Value="37" />
                                    <asp:ListItem Text="38" Value="38" />
                                    <asp:ListItem Text="39" Value="39" />
                                    <asp:ListItem Text="40" Value="40" />
                                    <asp:ListItem Text="41" Value="41" />
                                    <asp:ListItem Text="42" Value="42" />
                                    <asp:ListItem Text="43" Value="43" />
                                    <asp:ListItem Text="44" Value="44" />
                                    <asp:ListItem Text="45" Value="45" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnSepeteEkle" class="btn btn-light w-100" runat="server" Text="Sepete Ekle" OnClick="btnSepeteEkle_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
