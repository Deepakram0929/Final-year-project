<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterpage.Master" AutoEventWireup="true" CodeBehind="Replypage.aspx.cs" Inherits="cropPrediction.Admin.Replypage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 154px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelUpdatePassword" runat="server">

  
  <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Reply Farmer Query</h4>
</div>
</div>
</div>
   <!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	
	
      <table style="width: 85%;">
          <tr>
              <td>
                 <b>Query</b>
              </td>
              <td>
                  &nbsp;<span><asp:TextBox ID="txtQuery" runat="server" Height="150px" 
                      TextMode="MultiLine" Width="450px"></asp:TextBox>
                  </span>
              </td>
              <td>
                  &nbsp;
              <span>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                      ControlToValidate="txtQuery" CssClass="validation" 
                      ErrorMessage="Enter Query" ToolTip="Enter Query" 
                      ValidationGroup="pwd"></asp:RequiredFieldValidator>
                  </span>
              </td>
          </tr>
         
        
          <tr>
              <td class="style1">
                  <b>Reply</b>&nbsp;</td>
              <td class="style1">
                  <span>
                  <asp:TextBox ID="txtReply" runat="server" Height="150px" TextMode="MultiLine" 
                      Width="450px"></asp:TextBox>
                  </span></td>
              <td class="style1">
                  <span>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                      ControlToValidate="txtReply" CssClass="validation" ErrorMessage="Enter Reply" 
                      ToolTip="Enter Reply" ValidationGroup="pwd"></asp:RequiredFieldValidator>
                  </span></td>
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
                  <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                      Text="Send Reply" ValidationGroup="pwd" />
                  </span>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
      </table>


          <br />


        <br />

       </div>
</div>
</div>
                          

					 
			 
    </asp:Panel>

</asp:Content>
