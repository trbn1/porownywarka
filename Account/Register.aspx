<%@ Page Title="Rejestracja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Utwórz nowe konto.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Nazwa użytkownika</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="Podaj nazwę użytkownika" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Hasło</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Podaj hasło" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Potwierdź hasło</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Ponownie wprowadź hasło" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Poprawnie potwierdź hasło" />
            </div>
        </div>
               
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">E-mail</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Podaj e-mail" />
            </div>
        </div>
                
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Imię</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="Podaj imię" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Surname" CssClass="col-md-2 control-label">Nazwisko</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Surname" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Surname"
                    CssClass="text-danger" ErrorMessage="Podaj nazwisko" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Gender" CssClass="col-md-2 control-label">Płeć</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Gender" runat="server" AppendDataBoundItems="true">
                <asp:ListItem Value="-1">Wybierz</asp:ListItem>
                <asp:ListItem Value="M">Mężczyzna</asp:ListItem>
                <asp:ListItem Value="K">Kobieta</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Gender"
                    CssClass="text-danger" ErrorMessage="Wybierz płeć" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Bday" CssClass="col-md-2 control-label">Data urodzenia</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Bday" CssClass="form-control" placeholder="DD.MM.YYYY"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Bday"
                    CssClass="text-danger" ErrorMessage="Podaj datę urodzenia" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Phone" CssClass="col-md-2 control-label">Numer telefonu</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Phone" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Phone"
                    CssClass="text-danger" ErrorMessage="Podaj numer telefonu" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Street" CssClass="col-md-2 control-label">Ulica</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Street" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Street"
                    CssClass="text-danger" ErrorMessage="Podaj ulicę" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Number" CssClass="col-md-2 control-label">Numer domu</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Number" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Number"
                    CssClass="text-danger" ErrorMessage="Podaj numer domu" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="City" CssClass="col-md-2 control-label">Miasto</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="City" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="City"
                    CssClass="text-danger" ErrorMessage="Podaj miasto" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PostCode" CssClass="col-md-2 control-label">Kod pocztowy</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PostCode" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PostCode"
                    CssClass="text-danger" ErrorMessage="Podaj kod pocztowy" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="State" CssClass="col-md-2 control-label">Województwo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="State" runat="server" AppendDataBoundItems="true">
                <asp:ListItem Value="-1">Wybierz</asp:ListItem>
                <asp:ListItem>dolnośląskie</asp:ListItem>
                <asp:ListItem>kujawsko-pomorskie</asp:ListItem>
                <asp:ListItem>lubelskie</asp:ListItem>
                <asp:ListItem>lubuskie</asp:ListItem>
                <asp:ListItem>łódzkie</asp:ListItem>
                <asp:ListItem>małopolskie</asp:ListItem>
                <asp:ListItem>mazowieckie</asp:ListItem>
                <asp:ListItem>opolskie</asp:ListItem>
                <asp:ListItem>podkarpackie</asp:ListItem>
                <asp:ListItem>podlaskie</asp:ListItem>
                <asp:ListItem>pomorskie</asp:ListItem>
                <asp:ListItem>śląskie</asp:ListItem>
                <asp:ListItem>świętokrzyskie</asp:ListItem>
                <asp:ListItem>warmińsko-mazurskie</asp:ListItem>
                <asp:ListItem>wielkopolskie</asp:ListItem>
                <asp:ListItem>zachodniopomorskie</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="State"
                    CssClass="text-danger" ErrorMessage="Wybierz województwo" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Zarejestruj" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

