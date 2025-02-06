<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMasterpage.Master" AutoEventWireup="true" CodeBehind="_CropRecc.aspx.cs" Inherits="cropPrediction.Staff._CropRecc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panelContactus" runat="server">
<!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">CROP RECC (NB CLASSIFIER)!!!</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="contact">				
				<div class="contact_left">
				    <label>
                    <asp:DropDownList ID="ddlLoc" runat="server">
                    </asp:DropDownList>
                    </label>
				</div>				
				
  				<div class="clear"></div>	
                
                  <table style="width: 100%;">
             <tr>
                 <td>
                    
                     <br />
                     <asp:Panel ID="Panel1" runat="server">
                         <table style="width: 50%;">
                             <tr>
                                 <td>
                                     <b>PH</b></td>
                                 <td>
                                     <asp:TextBox ID="txtPH" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                         ControlToValidate="txtPH" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter PH Value" ValidationGroup="a">Enter PH Value</asp:RequiredFieldValidator>
                                     &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                         runat="server" ControlToValidate="txtPH" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     <b>Organic Carbon</b></td>
                                 <td>
                                     <asp:TextBox ID="txtOrganicCarbon" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                         ControlToValidate="txtOrganicCarbon" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter Organic Carbon" ValidationGroup="a">Enter Organic Carbon</asp:RequiredFieldValidator>
                                     &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                         runat="server" ControlToValidate="txtOrganicCarbon" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     <b>Nitrogen</b></td>
                                 <td>
                                     <asp:TextBox ID="txtNitrogen" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                         ControlToValidate="txtNitrogen" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter Nitrogen" ValidationGroup="a">Enter Nitrogen</asp:RequiredFieldValidator>
                                     &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                                         runat="server" ControlToValidate="txtNitrogen" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>
                             <tr>
                                 <td>
                                     <b>Phosphorus</b></td>
                                 <td>
                                     <asp:TextBox ID="txtPhosphorus" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                         ControlToValidate="txtPhosphorus" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter Phosphorus" ValidationGroup="a">Enter Phosphorus</asp:RequiredFieldValidator>
                                     &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
                                         runat="server" ControlToValidate="txtPhosphorus" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>

                               <tr>
                                 <td>
                                     <b>Potassium</b></td>
                                 <td>
                                     <asp:TextBox ID="txtPotassium" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                         ControlToValidate="txtPotassium" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter Potassium" ValidationGroup="a">Enter Potassium</asp:RequiredFieldValidator>
                                     &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
                                         runat="server" ControlToValidate="txtPotassium" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>

                               <tr>
                                 <td>
                                     <b>Sulphur</b></td>
                                 <td>
                                     <asp:TextBox ID="txtSulphur" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                         ControlToValidate="txtSulphur" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter Sulphur" ValidationGroup="a">Enter Sulphur</asp:RequiredFieldValidator>
                                     &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
                                         runat="server" ControlToValidate="txtSulphur" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>

                               <tr>
                                 <td>
                                     <b>Zinc</b></td>
                                 <td>
                                     <asp:TextBox ID="txtZinc" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                         ControlToValidate="txtZinc" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter Zinc" ValidationGroup="a">Enter Zinc</asp:RequiredFieldValidator>
                                     &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
                                         runat="server" ControlToValidate="txtZinc" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>

                               <tr>
                                 <td>
                                     <b>Iron</b></td>
                                 <td>
                                     <asp:TextBox ID="txtIron" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                         ControlToValidate="txtIron" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter Iron" ValidationGroup="a">Enter Iron</asp:RequiredFieldValidator>
                                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator8" 
                                         runat="server" ControlToValidate="txtIron" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>

                               <tr>
                                 <td>
                                     <b>Temperature</b></td>
                                 <td>
                                     <asp:TextBox ID="txtTemperature" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                         ControlToValidate="txtTemperature" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter Temperature" ValidationGroup="a">Enter Temperature</asp:RequiredFieldValidator>
                                     &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator9" 
                                         runat="server" ControlToValidate="txtTemperature" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>

                               <tr>
                                 <td>
                                     <b>Rainfall</b></td>
                                 <td>
                                     <asp:TextBox ID="txtRainfall" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                         ControlToValidate="txtRainfall" CssClass="failureNotification" ErrorMessage="*" 
                                         ToolTip="Enter Rainfall" ValidationGroup="a">Enter Rainfall</asp:RequiredFieldValidator>
                                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                                         runat="server" ControlToValidate="txtRainfall" CssClass="failureNotification" 
                                         ErrorMessage="*" ToolTip="only positive numbers" 
                                         ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$" ValidationGroup="a">only positive numbers</asp:RegularExpressionValidator>
                                 </td>
                             </tr>

                         </table>
                         <br />
                         <asp:Button ID="btnPrediction" runat="server" CssClass="btn" Height="50px" 
                             onclick="btnPrediction_Click" Text="Click here for Crop Recc" 
                             ValidationGroup="a" Width="250px" />
                         <br />
                         <br />
                         <asp:Table ID="tablePrediction" runat="server" Width="700px">
                         </asp:Table>
                         <br />
                        </asp:Panel>
                     <br />
                     <br />
                     &nbsp;&nbsp;&nbsp;
          <br /><br /><div>
                 </td>
                 <td align="left" valign="top">
                     &nbsp;
                 </td>
                 <td valign="top">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;
                 </td>
                 <td>
                     &nbsp;
                 </td>
             </tr>
             <tr>
                 <td>
                     &nbsp;
                 </td>
                 <td>
                     &nbsp;
                 </td>
                 <td>
                     &nbsp;
                 </td>
             </tr>
         </table>
            <br />	
             <marquee scrolldelay="150" behavior="alternate">
          <img src="../images/paddy6.jpg" width="300" height="180" alt="" /> &nbsp
          <img src="../images/paddy3.jpg" width="300" height="180" alt="" /> &nbsp
         <img src="../images/paddy8.jpg" width="300" height="180" alt="" /> &nbsp
          </marquee>
		  </div>
</div>
</div>
</div>


    </asp:Panel>
</asp:Content>
