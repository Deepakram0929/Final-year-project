<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="cropPrediction.Admin.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panelStaffs" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Create Departments</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="login_left">
        <!-- start registration -->
        <div class="registration">
            <div class="registration_left">
                <a href="#">
                <div class="reg_fb">
                    <i>add staff</i><div class="clear">
                    </div>
                </div>
                </a>
                <div class="registration_form">
                    <div>
                        <label>
                        <asp:Image ID="Image1" runat="server" Height="200px" 
                            ImageUrl="~/images/27825.png" Width="225px" />
                        <br />
                        <br />
                        <input ID="txtUserId" runat="server" placeholder="user Id:" tabindex="1" 
                            type="text">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtUserId" CssClass="failureNotification" 
                            ErrorMessage="Enter Type" ForeColor="#FF3300" ToolTip="Enter UserId" 
                            ValidationGroup="a"></asp:RequiredFieldValidator>
                        </input></label>
                    </div>
                    <div>
                        <label>
                        <input ID="txtPassword" runat="server" placeholder="password:" tabindex="1" 
                            type="text">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtPassword" CssClass="failureNotification" 
                            ErrorMessage="Enter Password" ForeColor="#FF3300" ToolTip="Enter Password" 
                            ValidationGroup="a"></asp:RequiredFieldValidator>
                        </input></label> 
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <div>
                        <label>
                        <input ID="txtLoc" runat="server" placeholder="Location:" tabindex="1" 
                            type="text">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtLoc" CssClass="failureNotification" 
                            ErrorMessage="Enter Location" ForeColor="#FF3300" ToolTip="Enter Location" 
                            ValidationGroup="a"></asp:RequiredFieldValidator>
                        </input></label> 
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <div>
                        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                            tabindex="2" Text="Submit" ValidationGroup="a" />
                    </div>
                </div>
                <br />
                <a href="#">
                <div class="reg_fb">
                    <i>view existing staffs</i><div class="clear">
                    </div>
                </div>
                </a>
                <div class="registration_form">
                    <div>
                        <div ID="popup">
                            <div style="height:400px; width:auto; overflow:auto">
                                <asp:Table ID="tableStaffs" runat="server" HorizontalAlign="Center">
                                </asp:Table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
	<div class="clear"></div>
</div>
</div>
</div>



    </asp:Panel>
</asp:Content>
