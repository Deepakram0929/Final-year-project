<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMasterpage.Master" AutoEventWireup="true" CodeBehind="_Graph.aspx.cs" Inherits="cropPrediction.Staff._Graph" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelStaffAccount" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Graph Generation</h4>
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
    <a href="#"><div class="reg_fb"><i>Graph</i><div class="clear"></div></div></a>
		 <div class="registration_form">
		 <!-- Form -->
			<form id="registration_form" action="contact.php" method="post">
                						
			
             <asp:Panel ID="panelUpdatePassword" runat="server">

  <div class="article">
          <h2><span>Graph</span> Representation (Algorithm Vs Accuracy)!!!</h2>
          <hr />
    
    		<br />
          <br />
          <div class="clear"></div>

          <strong>X - Axis : Algorithm, Y-Axis: Accuracy</strong><br />

    <asp:Chart ID="cTestChart" runat="server" Height="400px" Width="600px" 
            Visible="False">
			<Series>
				<asp:Series Name="Testing">
				</asp:Series>
			</Series>
			<ChartAreas>
				<asp:ChartArea Name="ChartArea1">
					<Area3DStyle />
				</asp:ChartArea>
			</ChartAreas>
		</asp:Chart>

          <br />
          <br />
          <div style="float:left;width:340px;">
              <div class="box">
                  <div class="registration_left">
                      <%-- <a href="#"><div class="reg_fb"><i>Select Chart Type</i><div class="clear"></div></div></a>--%>
                      <div class="registration_form">
                          <p>
                              <asp:DropDownList ID="ddlChartType" runat="server" AutoPostBack="False" 
                                  Visible="False">
                              </asp:DropDownList>
                          </p>
                      </div>
                      <div class="box">
                          <p>
                              <asp:RadioButtonList ID="rblValueCount" runat="server" AutoPostBack="False" 
                                  Visible="False">
                                  <asp:ListItem Value="10">10 Values</asp:ListItem>
                                  <asp:ListItem Value="20">20 Values</asp:ListItem>
                                  <asp:ListItem Value="50">50 Values</asp:ListItem>
                                  <asp:ListItem Value="100">100 Values</asp:ListItem>
                                  <asp:ListItem Selected="True" Value="500">500 Values</asp:ListItem>
                              </asp:RadioButtonList>
                          </p>
                      </div>
                  </div>
                  <div class="box">
                      <p>
                          <asp:CheckBox ID="cbUse3D" runat="server" AutoPostBack="False" 
                              Text="Use 3D Chart" Visible="False" />
                      </p>
                      <p>
                          <asp:RadioButtonList ID="rblInclinationAngle" runat="server" 
                              AutoPostBack="False" Visible="False">
                              <asp:ListItem Value="-90">-90°</asp:ListItem>
                              <asp:ListItem Value="-50">-50°</asp:ListItem>
                              <asp:ListItem Value="-20">-20°</asp:ListItem>
                              <asp:ListItem Value="0">0°</asp:ListItem>
                              <asp:ListItem Selected="True" Value="20">20°</asp:ListItem>
                              <asp:ListItem Value="50">50°</asp:ListItem>
                              <asp:ListItem Value="90">90°</asp:ListItem>
                          </asp:RadioButtonList>
                      </p>
                  </div>
              </div>
              <div>
                  <table style="width: 100%;">
                      <tr>
                          <td>
                              &nbsp;<asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show" 
                                  ValidationGroup="a" Visible="False" Width="125px" />
                              &nbsp;</td>
                      </tr>
                  </table>
              </div>
          </div>

        <br />

        </div>
        </asp:Panel>

        <br />



				
			</form>
			<!-- /Form -->
		</div>
	</div>
	</div>
	<!-- end registration -->
	</div>
	<div class="clear"></div>
</div>
</div>
</div>



    </asp:Panel>

</asp:Content>
