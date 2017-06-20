<%@ Page Title="Strona główna" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="background:transparent !important" class="jumbotron text-center">
        <h1>Porównywarka ofert operatorów sieci komórkowych</h1>
        <p class="lead">Skorzystaj już dziś z naszej innowacyjnej porównywarki ofert</p>
        <p><a href="porownywarka" class="btn btn-default btn-lg">Porównaj oferty &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Nim rozpoczniesz</h2>
            <p>
                Utwórz w pełni darmowe konto. Będziesz miał możliwość otrzymania spersonalizowanych ofert.
            </p>
            <p>
                <a class="btn btn-default" href="Account/Register">Załóż konto &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Android</h2>
            <p>
               Korzystaj z naszej aplikacji mobilnej. 
            </p>
            <p>
                <a class="btn btn-default" href="http://play.google.com">Pobierz &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>O nas</h2>
            <p>
                Jesteśmy niezwykle ambitnymi studentami, niestraszne nam żadne wyzwanie. Czasami popełniamy błędy ale zawsze zrobimy wszystko co w naszej mocy by je naprawić.
            </p>
            <p>
                <a class="btn btn-default" href="Contact">Skontaktuj się z nami &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
