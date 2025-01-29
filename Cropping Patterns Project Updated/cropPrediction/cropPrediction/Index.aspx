<!DOCTYPE HTML>
<html>
<head>
<title>Crop Prediction</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<link href='http://fonts.googleapis.com/css?family=Maven+Pro:400,900,700,500' rel='stylesheet' type='text/css'>
<link href="../css/style.css" rel="stylesheet" type="text/css" media="all" />
<!--- start-mmmenu-script---->
<script src="../js/jquery.min.js" type="text/javascript"></script>
<link type="text/css" rel="stylesheet" href="../css/jquery.mmenu.all.css" />
<script type="text/javascript" src="../js/jquery.mmenu.js"></script>
		<script type="text/javascript">
		    //	The menu on the left
		    $(function () {
		        $('nav#menu-left').mmenu();
		    });
		</script>
<!-- start slider -->
	<link href="../css/slider.css" rel="stylesheet" type="text/css" media="all" />
        <script type="text/javascript" src="../js/jquery.eislideshow.js"></script>
        <script type="text/javascript" src="../js/easing.js"></script>
        <script type="text/javascript">
            $(function () {
                $('#ei-slider').eislideshow({
                    animation: 'center',
                    autoplay: true,
                    slideshow_interval: 3000,
                    titlesFactor: 0
                });
            });
        </script>
<!-- start top_js_button -->
<script type="text/javascript" src="../js/move-top.js"></script>
   <script type="text/javascript">
       jQuery(document).ready(function ($) {
           $(".scroll").click(function (event) {
               event.preventDefault();
               $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1200);
           });
       });
	</script>
</head>
<body>
<!-- start header -->
<div class="top_bg">
<div class="wrap">
	<div class="header">
		<div class="logo">
			<%--<a href="Index.aspx"><img src="../images/logo3.png" alt=""/></a>--%>
             <h4 class="style">ML based Cropping Patterns System</h4>
		</div>
		<div class="log_reg">
				<ul>
					<li><a href="Login.aspx">User Login</a> </li>
									<span class="log"> or </span>
					<li><a href="Register.aspx">Register</a> </li>				   
					<div class="clear"></div>
				</ul>
		</div>		
						
		<div class="clear"></div>
	</div>	
</div>
</div>
<!-- start header_btm -->
<div class="wrap">
<div class="header_btm">
		<div class="menu">
			<ul>
			<li><a href="Index.aspx">Home</a></li>
				 <li><a href="AgriInfo.aspx">Agriculture Info</a></li>
				<li><a href="Contactus.aspx">Contactus</a></li>	
			</ul>
		</div>
		
	
	<div class="clear"></div>
</div>
</div>
<!-- start slider -->
<div class="slider">
				<!---start-image-slider---->
				<div class="image-slider">
					 <div class="wrapper">
                <div id="ei-slider" class="ei-slider">
                    <ul class="ei-slider-large">
						
                        <li>
                            <img src="../images/st7.jpg" alt="image02" />
                           
                        </li>
                        <li>
                            <img src="../images/st6.jpg" alt="image03"/>
                           
                        </li>
                        <li>
                            <img src="../images/st1.jpg" alt="image04"/>
                            
                        </li>
                        <li>
                            <img src="../images/st4.jpg" alt="image05"/>
                            
                        </li>
                      
                    </ul><!-- ei-slider-large -->
                    <ul class="ei-slider-thumbs">
                        <li class="ei-slider-element">Current</li>
						
                        <li class="hide1"><a href="#"><span></span></a><img src="../images/st7.jpg" alt="thumb01" /></li>
                        <li class="hide1"><a href="#"><span></span></a><img src="../images/st6.jpg" alt="thumb02" /></li>
                        <li class="hide1"><a href="#"><span></span> </a><img src="../images/st1.jpg" alt="thumb03" /></li>                        
                        <li><a href="#"><span></span></a><img src="../images/Paddy9.jpg" alt="thumb07" /></li>
                    </ul>
                    <!-- ei-slider-thumbs -->
                </div><!-- ei-slider -->
            </div><!-- wrapper -->
		</div>
		<!---End-image-slider---->	
</div>
<!-- start image1_of_3 -->

<!-- start main -->
<asp:Panel ID="panelAboutus" runat="server">

    <!-- start top_bg -->
<div class="top_bg">
<div class="wrap">
<div class="main_top">
	<h4 class="style">welcome to Crop Patterns system</h4>
</div>
</div>
</div>
<!-- start main -->
<div class="main_bg">
<div class="wrap">
<div class="main">
	<div class="about">
			 
	       	<div class="about-p">			       	
			       	<p class="para" align="justify">The cultivation of crops on land periodically throughout the year is a cropping pattern. This proposed work aims at prediction of major cropping patterns through only the cultivation-related factors like land, soil, and climate data using Machine Learning techniques. On a suitable land, farmers can grow many types of crops and there is a need of knowing the right cropping patterns to attain best profits. In the current agriculture sector there are the changes of reduction in crop yield, crop damages if farmer choose the random method of cropping. This is because proper crop yield depends on many agriculture parameters like temperature, rainfall, soli type, season etc... Machine learning unsupervised learning algorithms applied to process the agriculture data and to predict the cropping patterns. Algorithms like Apriori algorithm, Eclat algorithm or SFIT algorithms used.</p>
			       	
	      	</div>
	      	<div class="clear"></div>
	    	<div class="about-p">
		    	<p class="para" align="justify">The primary objective of this project work is to identify the best algorithm for predicting cropping pattern. Very less existing works on this pattern prediction, all existing works uses ready libraries for prediction and only model developed. Existing works uses static datasets for prediction. Existing works cannot be applied in real time. So in our proposed system we collect datasets manually and we build an automation for cropping pattern prediction useful for farmers and agriculture departments. System developed using tools such as Visual Studio front end tool and SQL Server as back end tool and we use more compatible and real time application supportive programming language C#. </p>
				
				
				
			</div>
	</div>
</div>
</div>
</div>


    </asp:Panel>

<!-- start footer -->
<div class="footer_mid">
<div class="wrap">

</div>
</div>
<!-- start footer -->
<div class="footer_bg">
<div class="wrap">
<div class="footer">
		<!-- scroll_top_btn -->
	    <script type="text/javascript">
	        $(document).ready(function () {

	            var defaults = {
	                containerID: 'toTop', // fading element id
	                containerHoverID: 'toTopHover', // fading element hover id
	                scrollSpeed: 1200,
	                easingType: 'linear'
	            };


	            $().UItoTop({ easingType: 'easeOutQuart' });

	        });
		</script>
		 <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 1;"></span></a>
		<!--end scroll_top_btn -->
	<div class="f_nav1">
		<ul>
			<li><a href="Index.aspx">home /</a></li>
			<li><a href="Aboutus.aspx">aboutus /</a></li>			
			<li><a href="Contactus.aspx">Contact us</a></li>
            <li><a href="Contactus.aspx">Agriculture Info</a></li>
		</ul>
		</div>
	<div class="copy">
		<p class="link"><span>© All rights reserved | Crop Prediction&nbsp;</span></p>
	</div>
	<div class="clear"></div>
</div>
</div>
</div>
</body>
</html>