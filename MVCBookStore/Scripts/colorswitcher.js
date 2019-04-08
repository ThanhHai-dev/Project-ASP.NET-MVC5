window.console=window.console||(function(){var c={};c.log=c.warn=c.debug=c.info=c.error=c.time=c.dir=c.profile=c.clear=c.exception=c.trace=c.assert=function(){};return c;})();jQuery(document).ready(function(){var styleswitcherstr=' \
	<div class="switcher-inner"> \
	<h2>Color Schemes <a href="#"></a></h2> \
    <div class="content"> \
    <div class="switcher-box"> \
	<ul class="color_schemes"> \
	<h3 class="skin_title"> Color Schemes</h3>\
	<li><a id="default" class="styleswitch color"> Default 	</a></li> \
	<li><a id="red" class="styleswitch color"> Red		</a></li> \
	<li><a id="blue" class="styleswitch color"> blue	</a></li> \
	<li><a id="orange" class="styleswitch color"> Orange		</a></li> \
	<li><a id="purple" class="styleswitch color"> Purple	</a></li> \
    </ul> </div><!-- End switcher-box --> \
    </div><!-- End content --> \
	';jQuery(".switcher").prepend(styleswitcherstr);});jQuery(document).ready(function(){var cookieName='wide';function changeLayout(layout){jQuery.cookie(cookieName,layout);jQuery('head link[name=layout]').attr('href','css/layout/'+ layout+'.css');}
if(jQuery.cookie(cookieName)){changeLayout(jQuery.cookie(cookieName));}
jQuery("#wide").click(function(){jQuery
changeLayout('wide');});jQuery("#boxed").click(function(){jQuery
changeLayout('boxed');});});jQuery(document).ready(function(){var startClass=jQuery.cookie('mycookie');jQuery("body").addClass("default");jQuery("#default").click(function(){jQuery("body").removeClass('red');jQuery("body").removeClass('blue');jQuery("body").removeClass('orange');jQuery("body").removeClass('purple');jQuery.cookie('mycookie','default');});jQuery("#red").click(function(){jQuery("body").removeClass('default');jQuery("body").removeClass('blue');jQuery("body").removeClass('orange');jQuery("body").removeClass('purple');jQuery.cookie('mycookie','red');});jQuery("#blue").click(function(){jQuery("body").removeClass('default');jQuery("body").removeClass('red');jQuery("body").removeClass('orange');jQuery("body").removeClass('purple');jQuery.cookie('mycookie','blue');});jQuery("#orange").click(function(){jQuery("body").removeClass('default');jQuery("body").removeClass('red');jQuery("body").removeClass('blue');jQuery("body").removeClass('purple');jQuery.cookie('mycookie','orange');});jQuery("#purple").click(function(){jQuery("body").removeClass('default');jQuery("body").removeClass('red');jQuery("body").removeClass('blue');jQuery("body").removeClass('orange');jQuery.cookie('mycookie','purple');});if(jQuery.cookie('mycookie')){jQuery('body').addClass(jQuery.cookie('mycookie'));}});jQuery(document).ready(function(){var cookieName='default';function changeLayout(layout){jQuery.cookie(cookieName,layout);jQuery('head link[name=skins]').attr('href','css/skins/'+ layout+'.css');}
if(jQuery.cookie(cookieName)){changeLayout(jQuery.cookie(cookieName));}
jQuery("#default").click(function(){jQuery
changeLayout('default');});jQuery("#red").click(function(){jQuery
changeLayout('red');});jQuery("#blue").click(function(){jQuery
changeLayout('blue');});jQuery("#orange").click(function(){jQuery
changeLayout('orange');});jQuery("#purple").click(function(){jQuery
changeLayout('purple');});});jQuery(document).ready(function(){jQuery('.switcher').animate({right:'-175px'});jQuery('.switcher h2 a').click(function(e){e.preventDefault();var div=jQuery('.switcher');if(div.css('right')==='-175px')
{jQuery('.switcher').animate({right:'0px'});}else
{jQuery('.switcher').animate({right:'-175px'});}})});