<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterpage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="cropPrediction.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelContactus" runat="server">

   
  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Farmer Register Form</h4>
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
		<!-- [if IE] 
		    < link rel='stylesheet' type='text/css' href='ie.css'/>  
		 [endif] -->  
		  
		<!-- [if lt IE 7]>  
		    < link rel='stylesheet' type='text/css' href='ie6.css'/>  
		<! [endif] -->  
		<script>
		    (function () {

		        // Create input element for testing
		        var inputs = document.createElement('input');

		        // Create the supports object
		        var supports = {};

		        supports.autofocus = 'autofocus' in inputs;
		        supports.required = 'required' in inputs;
		        supports.placeholder = 'placeholder' in inputs;

		        // Fallback for autofocus attribute
		        if (!supports.autofocus) {

		        }

		        // Fallback for required attribute
		        if (!supports.required) {

		        }

		        // Fallback for placeholder attribute
		        if (!supports.placeholder) {

		        }

		        // Change text inside send button on submit
		        var send = document.getElementById('register-submit');
		        if (send) {
		            send.onclick = function () {
		                this.innerHTML = '...Sending';
		            }
		        }

		    })();
		</script>
    
    		<br />

            <div class="registration_left">
		<a href="#"><div class="reg_fb"><i></i><div class="clear"></div></div></a>
		 <div class="registration_form">

              <table style="width: 100%;">
         <tr>
             <td>
                <b>Enter Id</b>
             </td>
             <td>
             <span>
                 <asp:TextBox ID="txtLoginId" runat="server" Height="25px" Width="200px"></asp:TextBox>
                 </span>
             </td>
             <td>
                 &nbsp;
             <span>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                     ControlToValidate="txtLoginId" CssClass="validation" 
                     ErrorMessage="Enter LoginId" ToolTip="Enter LoginId" ValidationGroup="mp" 
                     ForeColor="#CC3300"></asp:RequiredFieldValidator>
                 </span>
             </td>
         </tr>
         <tr>
             <td>
                <b>Enter Password</b>
             </td>
             <td>
             <span>
                 <asp:TextBox ID="txtPassword" runat="server" Height="25px" Width="200px" 
                     TextMode="Password"></asp:TextBox>
                 </span>
             </td>
             <td>
                 &nbsp;
             <span>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                     ControlToValidate="txtPassword" CssClass="validation" 
                     ErrorMessage="Enter Password" ToolTip="Enter Password" 
                     ValidationGroup="mp" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                 </span>
             </td>
         </tr>
         <tr>
             <td>
              <b>Select Location</b></td>
             <td>
             <span>
                  <asp:DropDownList ID="ddlLoc" runat="server">
                            <asp:ListItem>Mysore</asp:ListItem>
                            </asp:DropDownList>
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
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
                  <tr>
                      <td>
                          &nbsp;</td>
                      <td>
                          <span>
                          <asp:Button ID="Button1" runat="server" onclick="btnSubmit_Click" 
                              Text="Register" ValidationGroup="mp" />
                          </span>
                      </td>
                      <td>
                          &nbsp;</td>
                  </tr>
     </table>


     </div>
     </div>
              
           <br />



             
              
          </div>
			 

    </asp:Panel>



</asp:Content>
