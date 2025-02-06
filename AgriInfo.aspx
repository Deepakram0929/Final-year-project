<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterpage.Master" AutoEventWireup="true" CodeBehind="AgriInfo.aspx.cs" Inherits="cropPrediction.AgriInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAboutus" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">Agriculture Info</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
			 <div class="cont-grid-img img_style">
	     		
	     	</div>
	       <div class="about-p">
			       	<h4>Crop Prediction</h4>
			       	<p class="para" align="justify">First the farmers will take some soil of the agricultural field and get it tested by the lab. This process is called soil testing. An accurately calibrated soil test will indicate the degree of nutrient deficiency in a soil and estimate the nutrient rate required to optimize crop productivity. An efficient way to improve accuracy and efficiency in this process is to create a dataset with the data values collected over the years. By the use of technology and ML concepts, we can create an application which has the ability to suggest the best suitable crop. </p>
			       	
	      	</div>
	      	<div class="clear"></div>
	    	<div class="about-p">
		    	<p class="para" align="justify">The main inputs to the system will be the diagnosed nutritional features in soil directly from the lab test reports. We are using the ML concept and related Algorithm which can give the accurate output. The system based on dataset, will suggest the crops which can suit this soil type and can give profits to the farmer. The admin will manage the entire application by adding the different crop types, different soil and features of the soil. The farmer will take his field soil to lab, get the results, feed to the system and can view the results. As farmer will not be aware of this system, we try to feed these information by the help of other person. </p>
				
				
				
			</div>
	</div>
</div>
</div>
</div>


    </asp:Panel>

</asp:Content>
