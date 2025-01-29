<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="FeatureTypes.aspx.cs" Inherits="cropPrediction.Admin.FeatureTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 264px;
            height: 104px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panelFeaturesTypes" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Manage Parameters</h4>
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
      <a href="#"><div class="reg_fb"><i>add parameter</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		                						
				<div>
					<label>
						<img class="style1" 
                        src="../images/11.png" />
                    <br />
                    <br />
                    <input ID="txtType" runat="server" placeholder="parameter:" tabindex="1" 
                        type="text">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtType" CssClass="failureNotification" 
                        ErrorMessage="Enter Type" ForeColor="#FF3300" ToolTip="Enter Type" 
                        ValidationGroup="a"></asp:RequiredFieldValidator>
                    </input></label>
				    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
               
				<div>
                 <asp:Button ID="btnSubmit" runat="server" tabindex="2" Text="Submit" 
                        ValidationGroup="a" onclick="btnSubmit_Click" 
                        />
					
				</div>
		
		</div>

        <br />

         <a href="#"><div class="reg_fb"><i>view parameters</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 					
				<div>
					<div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">
                        <asp:Table ID="tableTypes" runat="server" HorizontalAlign="Center">
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
