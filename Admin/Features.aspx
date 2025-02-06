<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="Features.aspx.cs" Inherits="cropPrediction.Admin.Features" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panelFeatures" runat="server">
  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Manage Constraint Values</h4>
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
	<div class="registration_left">
      <a href="#"><div class="reg_fb"><i>add values</i><div class="clear"></div></div></a>
		 <div class="registration_form">

                <div>
					<asp:Image ID="Image1" runat="server" Height="200px" 
                        ImageUrl="~/images/123.jpg" Width="250px" />
					<label>
                       <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                       <asp:DropDownList ID="DropDownListType" runat="server" 
                                                      AutoPostBack="True" 
                                                      onselectedindexchanged="DropDownListType_SelectedIndexChanged" 
                                                      Width="100%">
                                                  </asp:DropDownList>
                        
                         <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                      ControlToValidate="DropDownListType" CssClass="failureNotification" 
                                                      ErrorMessage="Select Type" 
                        Operator="NotEqual" ToolTip="Select Type" 
                                                      ValidationGroup="a" ValueToCompare="- All -" 
                        ForeColor="#FF3300"></asp:CompareValidator>
						
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
               

		                						
				<div>
					<label>
						<input placeholder="value:" type="text" tabindex="2" runat="server" id="txtFeature">
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Enter Feature" ControlToValidate="txtFeature" 
                        CssClass="failureNotification" ToolTip="Enter Feature" 
                        ValidationGroup="a" ForeColor="#FF3300"></asp:RequiredFieldValidator>
					</label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
               
				<div>
                 <asp:Button ID="btnSubmit" runat="server" tabindex="2" Text="Submit" 
                        ValidationGroup="a" onclick="btnSubmit_Click" 
                        />
					
				</div>
		
		</div>

        <br />

         <a href="#"><div class="reg_fb"><i>view values</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 					
				<div>
					<div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">
                        <asp:Table ID="tableFeatures" runat="server" HorizontalAlign="Center">
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
