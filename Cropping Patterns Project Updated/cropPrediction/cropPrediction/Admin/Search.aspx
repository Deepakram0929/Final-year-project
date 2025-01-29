<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="cropPrediction.Admin.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelSearch" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Search Farmers</h4>
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
		        var send = document.getElementById('btnAdd');
		        if (send) {
		            send.onclick = function () {
		                this.innerHTML = '...Sending';
		            }
		        }

		    })();
		</script>
    
	<div class="registration_left">
      <a href="#"><div class="reg_fb"><i>search</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		                						
				<div>
					<label>
						<input placeholder="farmer name:" type="text" tabindex="1" runat="server" id="txtName">

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Enter Name" ControlToValidate="txtName" 
                        CssClass="failureNotification" ToolTip="Enter Name" 
                        ValidationGroup="a" ForeColor="#FF3300"></asp:RequiredFieldValidator>

					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
               
				<div>
                 <asp:Button ID="btnSubmit" runat="server" tabindex="2" Text="Submit" 
                        ValidationGroup="a" onclick="btnSubmit_Click" 
                        />
					
				</div>
		
		</div>

        <br />

        


	</div>
	</div>
        
        
			
	</div>
	<div class="clear"></div>
</div>
</div>
</div>

 <a href="#"><div class="reg_fb"><i>view farmers</i><div class="clear"></div></div></a>
		
		 					
				<div>
					<div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">
                        <asp:Table ID="tableFarmers" runat="server" HorizontalAlign="Center">
                        </asp:Table>
                        </div>
                        </div>


				</div>

    </asp:Panel>

</asp:Content>
