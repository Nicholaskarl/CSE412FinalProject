<%@ Page Title="Restraunt Searcher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE412FinalProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
            <div>
                <h2 id="introduction">Hello! This is the Tempe Restaurant Picker Assistant</h2>
                <p>
                    This generator will generate you a desired restaurant based on your price range, desired dining type, and other things.
                    Please first select your desired information(base is just the restaurant's name), criteria, then click the generation button.
                    Now you will have a list of restaurant's that fit your desires then you can go to the menu generator to continue narrowing down your options.
                </p>

            </div>
            <div>
            <h3 id="title1">Desired Information</h3>
            <asp:CheckBox ID="ContactInfo" runat="server" Text="ContactInfo" oncheckedchanged="ContactInfo_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:CheckBox ID="Address" runat="server" Text="Address" oncheckedchanged="Address_CheckedChanged" AutoPostBack="true" /> 
                <br />
            <asp:CheckBox ID="DiningType" runat="server" Text="DiningType" oncheckedchanged="DiningType_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:CheckBox ID="ParentCompany" runat="server" Text="ParentCompany" oncheckedchanged="ParentCompany_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:CheckBox ID="SupplierContactInfo" runat="server" Text="SupplierContactInfo" oncheckedchanged="SupplierContactInfo_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:CheckBox ID="GoogleRating" runat="server" Text="GoogleRating" oncheckedchanged="GoogleRating_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:CheckBox ID="MedianPriceRating" runat="server" Text="MedianPriceRating" oncheckedchanged="MedianPriceRating_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:CheckBox ID="GooglePriceRating" runat="server" Text="GooglePriceRating" oncheckedchanged="GooglePriceRating_CheckedChanged" AutoPostBack="true" />
                <br />
            <asp:Panel ID="panel1" runat="server"></asp:Panel>
            <h4 id="title2">Criteria</h4>
            </div>
            <div>  
            <asp:Label ID="DiningTypeDropDown" runat="server" Text="Dining Type"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" >  
                <asp:ListItem Value="Please Select">Please Select</asp:ListItem>  
                <asp:ListItem>Bar</asp:ListItem>  
                <asp:ListItem>Cafe</asp:ListItem>  
                <asp:ListItem>Casual</asp:ListItem>  
                <asp:ListItem>Casual Nice</asp:ListItem>  
                <asp:ListItem>Fast Food</asp:ListItem> 
                <asp:ListItem>Fine Dining</asp:ListItem>  
            </asp:DropDownList>  
            <br />
            <asp:Label ID="ParentCompanyDropDown" runat="server" Text="Parent Company"></asp:Label>
            <asp:DropDownList ID="ParentCompanyDropDownList" runat="server" >  
                <asp:ListItem Value="Please Select">Please Select</asp:ListItem>  
                <asp:ListItem>pc1</asp:ListItem>  
                <asp:ListItem>pc2</asp:ListItem>  
                <asp:ListItem>pc3</asp:ListItem>  
                <asp:ListItem>pc4</asp:ListItem>    
            </asp:DropDownList>  
            <br />
            <asp:Label ID="minGoogleRate" runat="server" Text="Minimum Google Rating"></asp:Label>
            <asp:TextBox ID="minGoogleInputData" runat="server"></asp:TextBox>
            <asp:Label ID="maxGoogleRate" runat="server" Text="Maximum Google Rating"></asp:Label>
            <asp:TextBox ID="maxGoogleInputData" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="minMedianPrice" runat="server" Text="Minimum Median Rating"></asp:Label>
            <asp:TextBox ID="minMedianInputData" runat="server"></asp:TextBox>
            <asp:Label ID="maxMedianPrice" runat="server" Text="Maximum Median Rating"></asp:Label>
            <asp:TextBox ID="maxMedianInputData" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="minGooglePrice" runat="server" Text="Minimum Google Price Rating"></asp:Label>
            <asp:TextBox ID="minGoogelPriceInputData" runat="server"></asp:TextBox>
            <asp:Label ID="maxGooglePrice" runat="server" Text="Maximum Google Price Rating"></asp:Label>
            <asp:TextBox ID="maxGoogelPriceInputData" runat="server"></asp:TextBox>
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
