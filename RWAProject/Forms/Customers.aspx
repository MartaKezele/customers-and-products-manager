<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Forms/Layout.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="RWAProject.Forms.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .doubleContainer {
            display: flex;
            flex-direction: row;
            justify-content: space-between;
        }

        .col1 {
            width: 63%;
        }

        .col2 {
            width: 33%;
        }

        .createBtn {
            width: 100%;
            height: 60%;
        }

        .centre {
            margin: 0;
            position: relative;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        .marginBottom {
            margin-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customers</h2>
    <div>
        <div class="doubleContainer marginBottom">
            <div class="col1">
                <table class="table centre">
                    <tr>
                        <td>Country
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCountries" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="AllCountriesSqlDataSource" DataTextField="Naziv" DataValueField="IDDrzava" OnSelectedIndexChanged="DdlCountries_SelectedIndexChanged"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="AllCountriesSqlDataSource" ConnectionString='<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>' SelectCommand="SELECT * FROM [Drzava] ORDER BY [Naziv]"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>City
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCities" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="CitiesInCountrySqlDataSource" DataTextField="Naziv" DataValueField="IDGrad" OnSelectedIndexChanged="DdlCities_SelectedIndexChanged"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="CitiesInCountrySqlDataSource" ConnectionString='<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>' SelectCommand="SELECT * FROM [Grad] WHERE ([DrzavaID] = @DrzavaID) ORDER BY [Naziv]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlCountries" PropertyName="SelectedValue" Name="DrzavaID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>Number of customers shown
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlNumberOfCustomersShown" runat="server" CssClass="form-control" AutoPostBack="true">
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col2">
                <asp:Button ID="btnCreate" runat="server" Text="Create new" CssClass="btn btn-success createBtn centre" OnClick="BtnCreate_Click" />
            </div>
        </div>
        <div class="doubleContainer">
            <div class="col1">
                <asp:GridView ID="gvCustomers" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="IDKupac" DataSourceID="CustomersInCitySqlDataSource" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" ViewStateMode="Disabled" OnSelectedIndexChanged="GvCustomers_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="IDKupac" HeaderText="IDKupac" ReadOnly="True" InsertVisible="False" SortExpression="IDKupac" Visible="False"></asp:BoundField>
                        <asp:BoundField DataField="Ime" HeaderText="First name" SortExpression="Ime"></asp:BoundField>
                        <asp:BoundField DataField="Prezime" HeaderText="Last name" SortExpression="Prezime"></asp:BoundField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox runat="server" Text='<%# Bind("Email") %>' ID="TextBox1"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Email", "<a href=mailto:{0}>{0}</a>") %>' ID="Label1"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Telefon" HeaderText="Phone"></asp:BoundField>
                        <asp:BoundField DataField="GradID" HeaderText="GradID" SortExpression="GradID" Visible="False"></asp:BoundField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Update" CssClass="btn btn-primary" CommandName="Select" CausesValidation="False" ID="LinkButton1"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

                    <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                    <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                    <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                    <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                    <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

                    <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="CustomersInCitySqlDataSource" ConnectionString='<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>' SelectCommand="SELECT * FROM [Kupac] WHERE ([GradID] = @GradID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlCities" PropertyName="SelectedValue" Name="GradID" Type="Int32"></asp:ControlParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
            <div id="createOrUpdateTable" runat="server" class="col2" visible="false">
                <h4 id="title" runat="server"></h4>
                <table class="table">
                    <tr>
                        <td>
                            <label>First name</label>
                        </td>
                        <td class="doubleContainer">
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="firstNameRequiredValidator"
                                runat="server"
                                ClientIDMode="Static"
                                ControlToValidate="txtFirstName"
                                Text="*"
                                ErrorMessage="First name is required."
                                Font-Bold="True"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Last name</label>
                        </td>
                        <td class="doubleContainer">
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="lastNameRequiredValidator"
                                runat="server"
                                ClientIDMode="Static"
                                ControlToValidate="txtLastName"
                                Text="*"
                                ErrorMessage="First name is required."
                                Font-Bold="True"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Email</label>
                        </td>
                        <td class="doubleContainer">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="emailRequiredValidator"
                                runat="server"
                                ClientIDMode="Static"
                                ControlToValidate="txtEmail"
                                Text="*"
                                ErrorMessage="Email is required."
                                Font-Bold="True"
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="emailFormatValidator"
                                runat="server"
                                ClientIDMode="Static"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ControlToValidate="txtEmail"
                                Text="*"
                                ErrorMessage="Email format is not valid."
                                Display="Dynamic"
                                Font-Bold="True"
                                ForeColor="Red">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Phone</label>
                        </td>
                        <td class="doubleContainer">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CustomValidator
                                ID="phoneNumberLengthValidator"
                                runat="server"
                                ControlToValidate="txtPhone"
                                ClientIDMode="Static"
                                Text="*"
                                ErrorMessage="Phone number must have 10-20 digits."
                                Font-Bold="true"
                                ForeColor="Red"
                                OnServerValidate="PhoneNumberLengthValidator_ServerValidate"
                                EnableClientScript="true"
                                ClientValidationFunction="PhoneNumberLengthValidation">
                            </asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Country</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUpdateCountries" runat="server" CssClass="form-control" AutoPostBack="true" DataSourceID="AllCountriesSqlDataSource" DataTextField="Naziv" DataValueField="IDDrzava"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>City</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUpdateCities" runat="server" CssClass="form-control" DataSourceID="CitiesInDdlUpdateCountrySqlDataSource" DataTextField="Naziv" DataValueField="IDGrad"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="CitiesInDdlUpdateCountrySqlDataSource" ConnectionString='<%$ ConnectionStrings:AdventureWorksOBPConnectionString %>' SelectCommand="SELECT * FROM [Grad] WHERE ([DrzavaID] = @DrzavaID) ORDER BY [Naziv]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlUpdateCountries" PropertyName="SelectedValue" Name="DrzavaID" Type="Int32"></asp:ControlParameter>
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="btn btn-success" CausesValidation="true" OnClick="BtnConfirm_Click" />
                        </td>
                        <td class="doubleContainer">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default" CausesValidation="false" OnClick="BtnCancel_Click" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CausesValidation="false" OnClick="BtnDelete_Click" />
                        </td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="validationSummary" runat="server" Font-Bold="True" ForeColor="Red" />
            </div>
            <div id="messageContainer" runat="server" class="col2" visible="false">
                <h4 id="message" runat="server"></h4>
            </div>
        </div>
    </div>
    <asp:Button ID="btnGenerateError" runat="server" Text="Generate error" CssClass="btn btn-danger" OnClick="BtnGenerateError_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
    <script>
        function PhoneNumberLengthValidation(sender, args) {
            if (args.Value.length >= 10 && args.Value.length <= 20) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>
