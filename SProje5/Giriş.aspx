<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Giriş.aspx.cs" Inherits="SProje5.Giriş" %>

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
        <h2>Giriş</h2>
        <asp:TextBox ID="txtEposta" runat="server" placeholder="E-Posta" CssClass="form-control mb-3"></asp:TextBox>
        <asp:TextBox ID="txtParola" runat="server" TextMode="Password" placeholder="Parola" CssClass="form-control mb-3"></asp:TextBox>
        <asp:CheckBox text="Oturumu Açık Tut" ID="chbOturumAcikTut" runat="server" />
        <asp:Button ID="btnGiris" runat="server" Text="Giriş" CssClass="btn w-50 mt-3" style="background-color:#6f64bd" OnClick="btnGiris_Click" />
        
    </div>
</asp:Content>


