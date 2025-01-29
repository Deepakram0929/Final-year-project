<%@ Page Title="" Language="C#" MasterPageFile="~/Farmer/FarmerMP.Master" AutoEventWireup="true" CodeBehind="FarmerHome.aspx.cs" Inherits="cropPrediction.Farmer.FarmerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelUpdatePassword" runat="server">

  
  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Post Query</h4>
</div>
</div>
</div>
   <!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	
	<div class="about">
	<div class="registration_form">
    
    		<br />
      <table style="width: 55%;">
          <tr>
              <td>
                 &nbsp;</td>
              <td>
                  <b>Enter Query</b>&nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
         
        
          <tr>
              <td>
                  &nbsp;</td>
              <td>
                  <span>
                  <asp:TextBox ID="txtQuery" runat="server" Height="150px" TextMode="MultiLine" 
                      Width="450px"></asp:TextBox>
                  </span>
              </td>
              <td>
                  &nbsp;
              </td>
          </tr>
         
        
          <tr>
              <td>
                  &nbsp;</td>
              <td>
                  <span>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                      ControlToValidate="txtQuery" CssClass="validation" ErrorMessage="Enter Query" 
                      ForeColor="#CC3300" ToolTip="Enter Query" ValidationGroup="pwd"></asp:RequiredFieldValidator>
                  </span></td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  &nbsp;</td>
              <td>
                  <asp:FileUpload ID="fileuploadPhoto" runat="server" />
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  &nbsp;</td>
              <td>
                  <span>
                  <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                      Text="Post Query" ValidationGroup="pwd" />
                  </span>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
      </table>


          <br />
          <asp:Table ID="Table1" runat="server">
          </asp:Table>
          <br />


        <br />


                        </div>  

					 
			 
    </asp:Panel>


</asp:Content>
