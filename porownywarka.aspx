<%@ Page Title="Porównywarka" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="porownywarka.aspx.cs" Inherits="Porównywarka" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Kliknij w parametr żeby posortować</h3>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:compdb %>" ProviderName="<%$ ConnectionStrings:compdb.providerName%>"  SelectCommand="SELECT Oferty.id_oferty, Oferty.koszt_sms, Oferty.pakiet_internetowy, Oferty.koszt_polaczenia_za_min, Oferty.waznosc_konta, Oferty.kwota_doladowania, Oferty.ocena_oferty, Operatorzy.nazwa_operatora FROM Oferty RIGHT JOIN Operatorzy ON Oferty.id_operatora = Operatorzy.id_operatora"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id_oferty" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id_oferty" HeaderText="ID Oferty" ReadOnly="True" SortExpression="id_oferty" />
                <asp:BoundField DataField="nazwa_operatora" DataFormatString="{0:0}" HeaderText="Nazwa operatora" SortExpression="nazwa_operatora" />
                <asp:BoundField DataField="koszt_sms" DataFormatString="{0:C}" HeaderText="Koszt SMS" SortExpression="koszt_sms" />
                <asp:BoundField DataField="pakiet_internetowy" DataFormatString="{0} GB" HeaderText="Pakiet internetowy" SortExpression="pakiet_internetowy" />
                <asp:BoundField DataField="koszt_polaczenia_za_min" DataFormatString="{0:C}" HeaderText="Koszt za min. połączenia" SortExpression="koszt_polaczenia_za_min" />
                <asp:BoundField DataField="waznosc_konta" DataFormatString="{0} dni" HeaderText="Ważność konta" SortExpression="waznosc_konta" />
                <asp:BoundField DataField="kwota_doladowania" DataFormatString="{0:C}" HeaderText="Kwota doładowania" SortExpression="kwota_doladowania" />
                <asp:BoundField DataField="ocena_oferty" HeaderText="Ocena oferty" SortExpression="ocena_oferty" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
