<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMasterpage.Master" AutoEventWireup="true" CodeBehind="ResultAnalysis.aspx.cs" Inherits="cropPrediction.Staff.ResultAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelUserLogin" Height="510px" runat="server">

 <div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Results</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
			
      
      <br />
        
      <asp:Table ID="Table1" runat="server">
      </asp:Table>
     
      <br />
        
     
        <asp:Button ID="btnGraph" runat="server" Height="50px" Text="Generate Graph" 
            Width="150px" onclick="btnGraph_Click1" Visible="False" />
        <br />
        
     
  </div>
  </div>
  </div>
  </div>
  
   </asp:Panel>

</asp:Content>
