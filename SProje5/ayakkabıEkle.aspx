<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ayakkabıEkle.aspx.cs" Inherits="SProje5.ayakkabıEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            background-color: #e4e4e4;
            padding: 20px;
            width: 700px;
            margin: 30px;
        }

        .resim {
            width: 250px;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="mb-3 mt-3">
            <label class="form-label">Ayakkabı Adı:</label>
            <asp:TextBox class="form-control w-75" ID="txtAyakkabiAdi" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="pwd" class="form-label">Fiyat (₺):</label>
            <asp:TextBox class="form-control w-75" ID="txtFiyat" runat="server"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <div class="col">
                <label class="filter-label" for="drpKategori">Kategori:</label>
                <asp:DropDownList ID="drpKategori" runat="server" CssClass="filter-dropdown"></asp:DropDownList>
            </div>
            <div class="col">
                <label class="filter-label" for="drpMarka">Marka:</label>
                <asp:DropDownList ID="drpMarka" runat="server" CssClass="filter-dropdown"></asp:DropDownList>
            </div>
            <div class="col">
                <label class="filter-label" for="drpRenk">Renk:</label>
                <asp:DropDownList ID="drpRenk" runat="server" CssClass="filter-dropdown"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <asp:FileUpload class="form-control" ID="Resim" runat="server" />
        </div>
        <asp:Button class="btn btn-primary w-25" ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
    </div>
</asp:Content>
