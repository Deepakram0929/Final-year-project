<%@ Page Title="" Language="C#" MasterPageFile="~/Farmer/FarmerMP.Master" AutoEventWireup="true" CodeBehind="_videospage.aspx.cs" Inherits="cropPrediction.Farmer._videospage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelUpdatePassword" runat="server">

  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">View Agriculture Videos</h4>
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
    	
            
    		<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
              Text="View Videos" />
          <br />
          <table style="width:100%;">
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
                      <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                  </td>
                  <td>
                      &nbsp;</td>
                  <td>
                      <asp:Literal ID="Literal2" runat="server"></asp:Literal>
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
                      &nbsp;</td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td>
                      &nbsp;</td>
                  <td>
                      &nbsp;</td>
              </tr>
          </table>
          <br />
    
    	
            
    		<br />
   

      
      </div>
                        
                          

					 
			 
    </asp:Panel>
</asp:Content>
