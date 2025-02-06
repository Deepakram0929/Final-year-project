<%@ Page Title="" Language="C#" MasterPageFile="~/Farmer/FarmerMP.Master" AutoEventWireup="true" CodeBehind="_Croppingpatterns.aspx.cs" Inherits="cropPrediction.Farmer._Croppingpatterns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
    <!-- Start contact Area -->  
<!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">View Cropping Patterns</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="contact">				
				<div class="contact_left">
      			<div class="company_address">
				     	
				   </div>
				</div>				
				
  				<div class="clear"></div>	
              
                                                                       
                <h2><span></span> Pattern Prediction Using Eclat Algorithm!!!</h2>
  <br />

    <asp:Table ID="Table4" runat="server">
    </asp:Table>
    <br />
  

               
            
    <asp:Panel ID="Panel2" runat="server" Visible="False" Width="721px">
        <h2>
            <span>PATTERNS DETAILS</span> !!!</h2>
        <table style="width: 75%;">
            <tr>
                <td style="width: 351px" valign="top">
                    <strong>Distinct Items</strong></td>
                <td>
                    <strong>Dataset</strong></td>
                <td>
                    TId</td>
            </tr>
            <tr>
                <td style="width: 351px" valign="top">
                    <asp:ListBox ID="lv_Items" runat="server" Height="175px" Width="211px">
                    </asp:ListBox>
                </td>
                <td style="width: 151px">
                    <asp:ListBox ID="lv_Transactions" runat="server" Height="175px" Width="324px">
                    </asp:ListBox>
                </td>
                <td style="width: 151px">
                    <asp:ListBox ID="lv_TransactionsId" runat="server" Height="175px" Width="150px">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 75%;">
            <tr>
                <td>
                    <strong>Frequent Item Set (L)</strong></td>
                <td>
                    <strong>Final Output [displaying patterns]</strong></td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server" Height="161px" Width="211px">
                    </asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="ListBox2" runat="server" Height="161px" Width="324px">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>


        

     

        <!-- End col-->
      </div>
    </div>
    </div>
  <!-- End Contact Area -->


    </asp:Panel>
</asp:Content>
