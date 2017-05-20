<%@ Page Title="Porównywarka" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="porownywarka.aspx.cs" Inherits="Porównywarka" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Kliknij w parametr żeby posortować</h3>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT [id_oferty], [id_operatora], [koszt_sms], [pakiet_internetowy], [koszt_polaczenia_za_min], [waznosc_konta], [kwota_doladowania], [ocena_oferty] FROM [Oferty]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_oferty" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id_oferty" HeaderText="ID Oferty" ReadOnly="True" SortExpression="id_oferty" />
                <asp:BoundField DataField="id_operatora" HeaderText="ID Operatora" SortExpression="id_operatora" />
                <asp:BoundField DataField="koszt_sms" HeaderText="Koszt SMS" SortExpression="koszt_sms" />
                <asp:BoundField DataField="pakiet_internetowy" HeaderText="Pakiet internetowy" SortExpression="pakiet_internetowy" />
                <asp:BoundField DataField="koszt_polaczenia_za_min" HeaderText="Koszt połączenia za min" SortExpression="koszt_polaczenia_za_min" />
                <asp:BoundField DataField="waznosc_konta" HeaderText="Ważność konta" SortExpression="waznosc_konta" />
                <asp:BoundField DataField="kwota_doladowania" HeaderText="Kwota doładowania" SortExpression="kwota_doladowania" />
                <asp:BoundField DataField="ocena_oferty" HeaderText="Ocena oferty" SortExpression="ocena_oferty" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
