<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="YeniKayit.aspx.cs" Inherits="SProje5.YeniKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .giriskart {
            width: 300px;
            margin: auto;
            margin-top: 50px;
            background-color: #24252b;
            padding: 30px;
            border-radius: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="giriskart">
        <h2>Hesab Oluştur</h2>
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" EnableViewState="false"></asp:Label>
        <asp:TextBox ID="txtAd" runat="server" placeholder="Ad" CssClass="form-control form-group mb-2"></asp:TextBox>
        <asp:TextBox ID="txtSoyad" runat="server" placeholder="Soyad" CssClass="form-control form-group mb-2"></asp:TextBox>
        <asp:TextBox ID="txtEposta" runat="server" placeholder="E-Posta" CssClass="form-control form-group mb-2"></asp:TextBox>
        <asp:TextBox ID="txtParola" runat="server" TextMode="Password" placeholder="Parola" CssClass="form-control mb-2 form-group"></asp:TextBox>
        <asp:Button ID="btnKayit" runat="server" Text="Kaydol" CssClass="btn w-50" Style="background-color: #6f64bd" OnClick="btnKayit_Click" />

    </div>
</asp:Content>
