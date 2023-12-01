<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CSE412FinalProject.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
            <div>
                <h2 id="introduction">Hello! This is the Tempe Restaurant Picker Assistant: Menu Sifter</h2>
                <p>
                    This generator will generate you a desired dish based on your price range, desired ingredients, and other things.
                    Please first select your desired information(base is just the restaurant's name), criteria, then click the generation button.
                    Now you will have a list of dishes's that fit your desires.(Please input lists of objects as follows 1 item:mayo; 2 items or more: mayo,cheese)
                </p>

            </div>
            <div>
            <h3 id="title1">Desired Information</h3>
            <asp:CheckBox ID="ItemName" runat="server" Text="Item Name" oncheckedchanged="ItemName_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:CheckBox ID="ItemOrigin" runat="server" Text="Item Origin" oncheckedchanged="ItemOrigin_CheckedChanged" AutoPostBack="true" /> 
                <br />
            <asp:CheckBox ID="ItemPrice" runat="server" Text="Item Price" oncheckedchanged="ItemPrice_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:CheckBox ID="ItemIngredients" runat="server" Text="Item Ingredients" oncheckedchanged="ItemIngredients_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:Panel ID="panel1" runat="server"></asp:Panel>
            <h4 id="title2">Criteria</h4>
            </div>
            <div>  
            <asp:Label ID="OriginDropDown" runat="server" Text="Origin of Food"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" >  
                <asp:ListItem Value="Please Select">Please Select</asp:ListItem>  
                <asp:ListItem>Mexican</asp:ListItem>  
                <asp:ListItem>Japanesse</asp:ListItem>  
                <asp:ListItem>American</asp:ListItem>  
                <asp:ListItem>Japanesse American</asp:ListItem>  
                <asp:ListItem>varies</asp:ListItem> 
            </asp:DropDownList>  
            <br />

            <asp:Label ID="minPriceLabel" runat="server" Text="Minimum Price of Dish"></asp:Label>
            <asp:TextBox ID="minPrice" runat="server">0</asp:TextBox>
            <asp:Label ID="maxPriceLabel" runat="server" Text="Maximum Price of Dish"></asp:Label>
            <asp:TextBox ID="maxPrice" runat="server">500</asp:TextBox>
            <br />
            <asp:Label ID="desiredIngredientsLabel" runat="server" Text="Please enter desired ingredients"></asp:Label>
            <asp:TextBox ID="DesiredIngredients" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="undersirableIngredientsLabel" runat="server" Text="Please enter ingredients to be excluded"></asp:Label>
            <asp:TextBox ID="undesireableIngredients" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="RestaurantLabel" runat="server" Text="Please enter The Restaurants you want to See(Please type the names exactly as they are presented in restaurant generator as punctuation cna cause issues.)"></asp:Label>
            <asp:TextBox ID="RestaurantTextBox" runat="server"></asp:TextBox>
            <br />
        </div>


        <div class="col">
            <asp:Button ID="GenerationButton" runat="server" Text="Load Data" OnClick="GenerateButton_Click" />

            <br />
            <asp:Label ID="Result2" runat="server" Text="Result"></asp:Label>
        </div>
    </main>

</asp:Content>
