<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMasterpage.Master" AutoEventWireup="true" CodeBehind="_CropPrediction.aspx.cs" Inherits="cropPrediction.Staff._CropPrediction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAboutus" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Suitable Crop Prediction Naive Bayes Algorithm</h4>
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
 <div style="height:500px; width:auto; overflow:auto">
<asp:GridView ID="GridView1" runat="server" BackColor="White" 
         BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" BorderStyle="None">

    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    <PagerStyle ForeColor="#000066" 
        HorizontalAlign="Left" BackColor="White" />
    <RowStyle ForeColor="#000066" />
    <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#007DBB" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#00547E" />

</asp:GridView>
</div>
          <br />
          <br />

           <h1><span>CROP </span>PREDICTION USING NAIVE BAYES ALGORITHM!!!</h1>
          <hr />

          <br />
          <asp:Button ID="btnPrediction" runat="server" 
                      Text="Click Here to Predict Crop" 
              onclick="btnPrediction_Click" CssClass="btn" /> &nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnResults" runat="server" CssClass="btn" 
              onclick="btnResults_Click" Text="Find Accuracy" />
          <br /><br /><div>
      <asp:Table ID="tablePrediction" runat="server">
      </asp:Table>
      </div>
          <br />


          </div>

	</div>
</div>
</div>
</div>


    </asp:Panel>
</asp:Content>
