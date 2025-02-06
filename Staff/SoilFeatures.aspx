<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMasterpage.Master" AutoEventWireup="true" CodeBehind="SoilFeatures.aspx.cs" Inherits="cropPrediction.Staff.SoilFeatures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelTypes" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Upload Dataset</h4>
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
      <a href="#"><div class="reg_fb"><i>Upload Parameters</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		                						
				<div>
					<label>
						<input placeholder="farmer name:" type="text" tabindex="1" runat="server" id="txtName">

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Enter Name" ControlToValidate="txtName" 
                        CssClass="failureNotification" ToolTip="Enter Name" 
                        ValidationGroup="a" ForeColor="#FF3300"></asp:RequiredFieldValidator>

					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Table 
                        ID="tableAttributes" runat="server">
                    </asp:Table>
                </div>
               
		</div>

         <a href="#"><div class="reg_fb"><i>Select Crop</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 					
				<div>
					    <asp:Panel ID="panelOutput" runat="server">
                    
                       
                        <div class="span8">
                        <h2 class="title"><span>Set Crop</span></h2>
                            <table style="width:100%;">

                                <tr>
                                    <td>
                                        <strong>Crop Type</strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="DropdownListTypes" runat="server" 
                                            onselectedindexchanged="DropdownListTypes_SelectedIndexChanged" 
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                            ControlToValidate="DropdownListTypes" CssClass="failureNotification" 
                                            ErrorMessage="Select Type" Operator="NotEqual" ToolTip="Select Type" 
                                            ValidationGroup="a" ValueToCompare="Select" ForeColor="Red"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <strong>Crop</strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="DropdownListCrops" runat="server">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                            ControlToValidate="DropdownListCrops" CssClass="failureNotification" 
                                            ErrorMessage="Select Crop" Operator="NotEqual" ToolTip="Select Crop" 
                                            ValidationGroup="a" ValueToCompare="Select" ForeColor="Red"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>


                            
                                        <br />
                            <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                                Text="Upload" ValidationGroup="a" />
                            &nbsp;<asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                                Text="Delete" />
                        </div>
                        
                    
                    
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
