<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMasterpage.Master" AutoEventWireup="true" CodeBehind="cropRecc_NB.aspx.cs" Inherits="cropPrediction.Staff.cropRecc_NB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelTypes" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Crop Recommendation Module</h4>
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

         <a href="#"><div class="reg_fb"><a href="#"><i>Upload Parameters</i></a></div></a>
		 <div class="registration_form">
		 					
				<div>
					    <asp:Panel ID="panelOutput" runat="server">
                    
                       
                        
                       
                            <table style="width:100%;">

                               
                               
                               
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtField" runat="server"></asp:TextBox>
                                         
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Enter Name" ControlToValidate="txtField" 
                        CssClass="failureNotification" ToolTip="Enter Name" 
                        ValidationGroup="a" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <h3>
                                            Set Parameters</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <asp:Table ID="tableAttributes" runat="server">
                                            </asp:Table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                                            tabindex="2" Text="Crop Prediction (Naive Bayes)" ValidationGroup="a" />
                                    </td>
                                </tr>
                            </table>
                        
                        
                    <div>
                        <label>
                        &nbsp;</input></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox 
                            ID="txtRecc" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

                        

                                        <br />
                    
                    </asp:Panel>


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
