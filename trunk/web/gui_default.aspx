<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gui_default.aspx.cs" Inherits="web.gui_default" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/gui_songNumber.ascx" TagPrefix="uc1" TagName="gui_songNumber" %>
<%@ Register Src="~/gui_currentList.ascx" TagName="gui_currentList" TagPrefix="uc2" %>
<%@ Register Src="~/gui_video.ascx" TagPrefix="uc3" TagName="gui_video" %>
<%@ Register Src="~/gui_volume.ascx" TagPrefix="uc4" TagName="gui_volume" %>
<%@ Register Src="~/gui_find.ascx" TagPrefix="uc0" TagName="gui_find" %>
<%@ Register Src="~/gui_tune.ascx" TagPrefix="uc5" TagName="gui_tune" %>
<%@ Register Src="~/gui_advanced.ascx" TagPrefix="uc6" TagName="gui_advanced" %>
<%@ Register Src="~/ErrorDeadWCF.ascx" TagPrefix="uc7" TagName="wcferror" %>










<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="icon" href="/images/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="/images/favicon.ico" type="image/x-icon" />
    <link rel="apple-touch-icon" href="/images/crazyktv.png" />
    <link rel="apple-touch-icon-precomposed" href="/images/crazyktv.png" />

    <!--Mobile specific meta goodness-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <!-- Adding "maximum-scale=1" fixes the Mobile Safari auto-zoom bug: http://filamentgroup.com/examples/iosScaleBug/ -->

    <link href="Content/bootstrap.min.css" rel="stylesheet" /> 
    <link href="css/gui_layout.css" rel="stylesheet" />
    <link href="css/gui_button.css" rel="stylesheet" />
    <link href="css/gui_overlay.css" rel="stylesheet" />

    <!--[if lt IE 9]>
        <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <script src="Scripts/IE9html5.js"></script>
    <![endif]-->

    
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/jquery.watermark.js"></script>
    <script src="Scripts/hammer.js"></script>
    <script src="Scripts/jquery.specialevent.hammer.js"></script>

    <meta charset="utf-8" />
    <title>CrazyKTV</title>
</head>
<body dir='<asp:Literal ID="Literal1" runat="server" Text="<%$Resources: GlobalMessages, directionltr %>"></asp:Literal>'>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableHistory="True">
        </asp:ScriptManager>


        <script type="text/javascript">
            $(document).ready(function () {

                AfterPostBack();
                // You are calling this function the page loads for the first time

                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(AfterPostBack);

                //  EndRequest added on endRequest of Postback..  This is when the page pots back..
                // Called when postback occurs

            });





            var AfterPostBack = function () {
                // You write your code here to assign Data
               
                if ($('#ddlanguage').val() == "en-US")
                { $('#tSearch').watermark('All Songs'); }
                else { $('#tSearch').watermark('全部歌曲'); }

            

                if ($('#findCaller').val() == "toTop") {
                    $("html, body").animate({ scrollTop: 0 }, "slow");
                    //return false;
                }

                $(document).ready(function () {
                    $("#down").css("height", $("#BChannel").height() + "px");
                    $("#up").css("height", $("#BChannel").height() + "px");
                    $(".arrowSpacer").css("height", $("#BChannel").height() + "px");
                    $(".arrowSpacer").css("width", $("#BChannel").height() + "px");

                    if ($('#Showsuball').val() == "0")
                    { Hidesuball(); }
                    else { Showsuball(); }
                })

                $("#up").click(function () {
                    Showsuball();
                });

                $("#down").click(function () {
                    Hidesuball();
                });

                $(".arrowSpacer").click(function () {
                    Hidesuball();
                });

                
                function Showsuball() {
                    //$("#alwaysVisibleDiv").animate({ bottom: ($(window).height() - $("#alwaysVisibleDiv").height()) * 0.85 + 'px' }, "slow");
                    //$("#suball").css("height", ($(window).height() - $("#alwaysVisibleDiv").height()) * 0.85 + 'px');
					$("#suball").css("display", "block");
                    $("#alwaysVisibleDiv").animate({ bottom: ($("#BChannel").height()*5) +10*5 + 'px' }, "fast");
                    $("#suball").css("height", ($("#BChannel").height()*5 ) +10*5 + 'px');
                    $("#down").css("display", "inline-block");
                    $("#up").css("display", "none");
                    $('#Showsuball').val("1");
                }

                function Hidesuball()
                {
                    $("#alwaysVisibleDiv").animate({ bottom: '-0px' }, "fast");
                    $("#up").css("display", "inline-block");
                    $("#down").css("display", "none");
                    $("#suball").css("display", "none");
                    $('#Showsuball').val("0");
                }


                $('#ddSearchType').change(function () {
                    var _value = $('#ddSearchType').val();
                    if (_value == "Song" || _value == "Singer" || _value == "WordCount") {
                        $('#tSearch').show();
                    }
                    else if (_value.toLowerCase().indexOf("---") >= 0) {
                        $('#tSearch').hide();
                    }
                    else {
                        $('#tSearch').hide();
                        $('#bSearch').click();
                    }

                });

                $('#ddSearchType').ready(function () {
                    var _value = $('#ddSearchType').val();
                    if (_value == "Song" || _value == "Singer" || _value == "WordCount") {
                        $('#tSearch').show();
                    }
                    else {
                        $('#tSearch').hide();
                    }
                });

                //touch events

                function hammerLog(event) {
                    event.preventDefault();
                    //$output.prepend( "Type: " + event.type + ", Fingers: " + event.touches.length + ", Direction: " + event.direction + "<br/>" );
                    //$('#output').prepend("Type: " + event.type + ", Fingers: " + event.touches.length + ", Direction: " + event.direction + ", scale:" + event.scale + "<br/>");

                    //alert("testaa");
                   // Showsuball();

                    if (event.direction == "down") {
                        Hidesuball();
                    }
                    else if (event.direction == "up")
                        {
                        Showsuball();
                     }

                }




                //var actions = 'hold tap swipe doubletap transformstart transform transformend dragstart drag dragend release';
                //var actions = 'swipe';

                //register each DOM jquery events
                //$("#alwaysVisibleDiv").find("*").on('tap', hammerLog);
                $("#alwaysVisibleDiv").children('*').on('swipe', hammerLog);
                $("#alwaysVisibleDiv").on('swipe', hammerLog);
                $("#suball").children('*').on('swipe', hammerLog);
                $("#suball").on('swipe', hammerLog);
                
                //$("*").on('tap', hammerLog);

                /*	
				(function ($) {
                    $("*").on(actions, hammerLog);
                }(jQuery));
				*/


                //touch events END

                return false;


            }
        </script>


        
        <asp:HiddenField ID="Showsuball" runat="server" Value="0" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <header id="masterheader">
                    <section>
                    <div id="headarea">
                        <asp:Image ID="CrazyKTVLogo" ImageUrl="images/main_crazyktv.png" runat="server" CssClass="Mainlogo"/>
                        <asp:ImageButton ID="PlayListButton" ImageUrl="images/main_playlist.png" runat="server" CssClass="Mainbutton" OnClick="PlayListButton_Click"/>
                        <asp:ImageButton ID="FindSongButton" ImageUrl="images/main_findsong.png" runat="server" CssClass="Mainbutton" OnClick="FindSongButton_Click"/>
                        <asp:ImageButton ID="SongNumberButton" ImageUrl="images/main_songnumber.png" runat="server" CssClass="Mainbutton" OnClick="SongNumberButton_Click"/>
                        <asp:ImageButton ID="AdvancedButton" ImageUrl="images/main_advanced.png" runat="server" CssClass="Mainbutton" OnClick="AdvancedButton_Click"/>
                    </div>
                                        
                        <div id="spacerToTop">
                            <asp:Image ID="MainEmptyImage" ImageUrl="images/main_emptyimage.png" runat="server" CssClass="MainEmptyImage"/>
                        </div>
                    </section>

                    
                    <nav>


                        
                        
                        <div style="display: block">
                            
                            <div style="float: left; width: 50%; display: block">
                                <asp:Label ID="lFunctions" runat="server" Visible="False" Text="Functions: " meta:resourcekey="lFunctionsResource1" CssClass="label1"></asp:Label>
                                <asp:DropDownList ID="ddActions" runat="server" Visible="False" AutoPostBack="True" CssClass="dropdown1" meta:resourcekey="ddActionsResource1" OnSelectedIndexChanged="ddActions_SelectedIndexChanged">
                                    <asp:ListItem meta:resourcekey="ListItemResource30" Text="---------"></asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource20" Text="Find" Value="Find"></asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource21" Text="Song Number"></asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource22" Text="Waiting List"></asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource23" Text="Video"></asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource24" Text="Volume"></asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource25" Text="Pitch" Value="Tune"></asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource26" Text="Advanced"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div style="float: right; width: 50%; display: block">
                                <asp:Label ID="lLanguage" runat="server" Visible="False" Text="Language: " CssClass="label1" meta:resourcekey="lLanguageResource1"></asp:Label>
                                <asp:DropDownList ID="ddlanguage" runat="server" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="language_SelectedIndexChanged" CssClass="dropdown1" meta:resourcekey="ddlanguageResource1">
                                    <asp:ListItem Value="en-US" Text="English" meta:resourcekey="ListItemResource14"></asp:ListItem>
                                    <asp:ListItem Value="zh-CHT" Text="繁體中文" meta:resourcekey="ListItemResource15"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </nav>
                </header>

                <article id="mainarea">
                    <section>
                        <div>
                            <uc1:gui_songNumber runat="server" ID="gui_songNumber" Visible="False" />
                            <uc2:gui_currentList ID="gui_currentList1" runat="server" Visible="False" />
                            <uc3:gui_video runat="server" ID="gui_video" Visible="False" />
                            <uc4:gui_volume runat="server" ID="gui_volume" Visible="False" />
                            <uc5:gui_tune runat="server" ID="gui_tune" Visible="False" />
                            <uc6:gui_advanced runat="server" ID="gui_advanced" Visible="False" />
                            <uc0:gui_find runat="server" ID="gui_find" Visible="False" ClientIDMode="Static" />
                            <uc7:wcferror runat="server" ID="wcferror" Visible="False" ClientIDMode="Static" />
                        </div>
                        <div class="spacerToFooter" />
                    </section>
                </article>

                <style>
                    #alwaysVisibleDiv {
                        position: fixed;
                        bottom: 0px;
                        left: 0px;
                        text-align: center;
                        display: inline;
                        width: 100%;
                        background-color: #000000;
                        z-index: 10;
                    }
                </style>
                <div style="clear: both;" />
                <div id="alwaysVisibleDiv">
                    <asp:Button ID="BChannel" runat="server" Text="導唱" CssClass="button4" OnClick="BChannel_Click" meta:resourcekey="BChannelResource1" />
                    <asp:Button ID="BFind" runat="server" Text="點歌" CssClass="button4" OnClick="BFind_Click" meta:resourcekey="BFindResource1" />
                    <asp:Button ID="BCut" runat="server" Text="切歌" CssClass="button4" OnClick="BCut_Click" OnClientClick="return confirm('確認切歌?');" meta:resourcekey="BCutResource1" />

                    <img id="up" style="display: inline-block;  max-width:48px; vertical-align:middle;" src="images/Arrow.gif" />
                    <img id="down" style="display: none; max-width:48px; vertical-align:middle;" src="images/Arrow2.gif" />
                    <div id="all" style="display: block; height: 0px; background-color: #000000;">
                        <div id="suball" style="display: none; background-color: #000000;">

                            <div id="row1" style="display: block;">
                                <asp:Button ID="BdRestart" runat="server" Text="重播" CssClass="button4" OnClick="BdRestart_Click" meta:resourcekey="BdRestartResource1" />
                                <asp:Button ID="BdKeyDown" runat="server" Text="-key" CssClass="button4" OnClick="BdKeyDown_Click" meta:resourcekey="BdKeyDownResource1" />
                                <asp:Button ID="BdKeyUp" runat="server" Text="+key" CssClass="button4" OnClientClick=";" OnClick="BdKeyUp_Click" meta:resourcekey="BdKeyUpResource1" />
                                <div class="arrowSpacer" style="display: inline-block"></div>
                            </div>
                             <div id="row2" style="display: block;">
                                <asp:Button ID="BdRepeat" runat="server" Text="隨機" CssClass="button4" OnClick="BdRepeat_Click" meta:resourcekey="BdRepeatResource1" />
                                <asp:Button ID="BdMale" runat="server" Text="男調" CssClass="button4" OnClick="BdMale_Click" meta:resourcekey="BdMaleResource1" />
                                <asp:Button ID="BdFemale" runat="server" Text="女調" CssClass="button4" OnClientClick=";" OnClick="BdFemale_Click" meta:resourcekey="BdFemaleResource1" />
                                <div class="arrowSpacer" style="display: inline-block"></div>
                            </div>
                            <div id="row3" style="display: block;">
                                <asp:Button ID="BdPause" runat="server" Text="暫停" CssClass="button4" OnClick="BdPause_Click" meta:resourcekey="BdPauseResource1" />
                                <asp:Button ID="BdBackward" runat="server" Text="快後" CssClass="button4" OnClick="BdBackward_Click" meta:resourcekey="BdBackwardResource1" />
                                <asp:Button ID="BdForward" runat="server" Text="快前" CssClass="button4" OnClientClick=";" OnClick="BdForward_Click" meta:resourcekey="BdForwardResource1" />
                                <div class="arrowSpacer" style="display: inline-block"></div>
                            </div>
                            <div id="row4" style="display: block;">                                
                                <asp:Button ID="BdMute" runat="server" Text="壞歌" CssClass="button4" OnClick="BdMute_Click" meta:resourcekey="BdMuteResource1" />
                                <asp:Button ID="BdVolumeDown" runat="server" Text="-音量" CssClass="button4" OnClick="BdVolumeDown_Click" meta:resourcekey="BdVolumeDownResource1"  />
                                <asp:Button ID="BdColumeUp" runat="server" Text="+音量" CssClass="button4" OnClientClick=";" OnClick="BdColumeUp_Click" meta:resourcekey="BdColumeUpResource1" />
                                <div class="arrowSpacer" style="display: inline-block;"></div>
                            </div>
                        </div>
                    </div>




                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            <div class="overlay" />
                            <div class="overlayContent" id="overlayContent1">
                                <h2>
                                    <asp:Label ID="lLoading" runat="server" Text="Loading..." meta:resourcekey="lLoadingResource1"></asp:Label></h2>
                                <img src="/images/ajax-loader.gif" alt="Loading" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>












        <%--         <img id="displayBox" src="/images/ajax-loader.gif" width="32" height="32" style="display:none" />--%>

        <%--        <script>

            //jQuery.fn.center = function () {
            //    this.css("position", "absolute");
            //    this.css("top", (($(window).height() - this.outerHeight()) / 2) +
            //                                        $(window).scrollTop() + "px");
            //    this.css("left", (($(window).width() - this.outerWidth()) / 2) +
            //                                        $(window).scrollLeft() + "px");
            //    return this;
            //}

            //$(function () {
            //    $('#UpdateProgress1').center();
            //});



            //$(document).ready(function () {
            //    $('#form1').submit(function () {
            //        $.blockUI({
            //            message: $('#displayBox'),
            //            css: {
            //                top: ($(window).height() - 32) / 2 + 'px',
            //                left: ($(window).width() - 32) / 2 + 'px',
            //                width: '32px'
            //            }
            //        });

            //        setTimeout($.unblockUI, 0);
            //    });
            //});

            //$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

            

            //$(document).ready(function () {
            //    $('#form1').change(function () {
            //        $.blockUI({
            //            message: $('#UpdateProgress1'),
            //            css: {
            //                top: ($(window).height() - 32) / 2 + 'px',
            //                left: ($(window).width() - 32) / 2 + 'px',
            //                width: '32px'
            //            }
            //        });

            //         setTimeout($.unblockUI, 0);
            //        //$(document).ajaxStop($.unblockUI);

            //    });
            //});


            //// Get a reference to the PageRequestManager.
            //var prm = Sys.WebForms.PageRequestManager.getInstance();

            //// Unblock the form when a partial postback ends.
            //prm.add_endRequest(function () {
            //    $('#form1').unblock();
            //});


            
            //jQuery.fn.center = function () {
            //    this.css("position", "absolute");
            //    this.css("top", Math.max(0, (($(window).height() - $(this).outerHeight()) / 2) + $(window).scrollTop()) + "px");
            //    this.css("left", Math.max(0, (($(window).width() - $(this).outerWidth()) / 2) + $(window).scrollLeft()) + "px");
            //    return this;
            //}

            //$('#UpdateProgress1').center();



 


        </script>--%>
    </form>


</body>
</html>
