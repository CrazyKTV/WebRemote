<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web._default" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/songNumber.ascx" TagPrefix="uc1" TagName="songNumber" %>
<%@ Register Src="~/currentList.ascx" TagName="currentList" TagPrefix="uc2" %>
<%@ Register Src="~/video.ascx" TagPrefix="uc3" TagName="video" %>
<%@ Register Src="~/volume.ascx" TagPrefix="uc4" TagName="volume" %>
<%@ Register Src="~/find.ascx" TagPrefix="uc0" TagName="find" %>
<%@ Register Src="~/tune.ascx" TagPrefix="uc5" TagName="tune" %>
<%@ Register Src="~/advanced.ascx" TagPrefix="uc6" TagName="advanced" %>










<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="icon" href="/images/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="/images/favicon.ico" type="image/x-icon" />
    <!--Mobile specific meta goodness-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <!-- Adding "maximum-scale=1" fixes the Mobile Safari auto-zoom bug: http://filamentgroup.com/examples/iosScaleBug/ -->

    <link href="css/layout.css" rel="stylesheet" />
    <link href="css/overlay.css" rel="stylesheet" />
    <!--[if lt IE 9]>
        <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <script src="IE9html5.js"></script>
    <![endif]-->
    <!-- Favicons-->
    <!--<link rel="shortcut icon" href="img/favicon.ico">-->
    <script src="jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="jquery.watermark.js"></script>
    <%--<script src="jquery.blockUI.js"></script>--%>
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
                // to the calender
                //window.scrollTo(0, 0);
                // $("html, body").animate({ scrollTop: 0 }, "slow");
                //return false;
                //$('#BPrevious')..click(function() {
                //    $("html, body").animate({ scrollTop: 0 }, "slow");
                //    return false;
                //});

                //$('#BNext').click(function () {
                //    $("html, body").animate({ scrollTop: 0 }, "slow");
                //    return false;
                //});

                //if ($("#ddActions option:selected").val() == "Waiting List") {
                //    $.
                //    //return false;
                //}

                

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
                    $(".arrowSpacer").css("width", $("#down").width() + "px");
					$("#suball").css("display", "none");
                })

                $("#up").click(function () {
                    //$("#alwaysVisibleDiv").animate({ bottom: ($(window).height() - $("#alwaysVisibleDiv").height()) * 0.85 + 'px' }, "slow");
                    //$("#suball").css("height", ($(window).height() - $("#alwaysVisibleDiv").height()) * 0.85 + 'px');
					$("#suball").css("display", "block");
                    $("#alwaysVisibleDiv").animate({ bottom: ($("#BChannel").height()*5) +10*5 + 'px' }, "fast");
                    $("#suball").css("height", ($("#BChannel").height()*5 ) +10*5 + 'px');
                    $("#down").css("display", "inline-block");
                    $("#up").css("display", "none");
                });

                $("#down").click(function () {
                    $("#alwaysVisibleDiv").animate({ bottom: '-0px' }, "fast");
                    $("#up").css("display", "inline-block");
                    $("#down").css("display", "none");
                    $("#suball").css("display", "none");
                });

                $(".arrowSpacer").click(function () {
                    $("#alwaysVisibleDiv").animate({ bottom: '-0px' }, "fast");
                    $("#up").css("display", "inline-block");
                    $("#down").css("display", "none");
                    $("#suball").css("display", "none");
                });

                


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



                return false;


            }
        </script>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <header id="masterheader">
                    <section>
                        <asp:Label ID="LComputerOnlyMessage" runat="server" Text="'F11' on the keyboard to activate/diactivate full screen." meta:resourcekey="LComputerOnlyMessageResource1"></asp:Label>
                    </section>
                    <nav>
                        <div style="display: block">
                            <div style="float: left; width: 50%; display: block">
                                <asp:Label ID="lFunctions" runat="server" Text="Functions: " meta:resourcekey="lFunctionsResource1" CssClass="label1"></asp:Label>
                                <asp:DropDownList ID="ddActions" runat="server" AutoPostBack="True" CssClass="dropdown1" meta:resourcekey="ddActionsResource1" OnSelectedIndexChanged="ddActions_SelectedIndexChanged">
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
                                <asp:Label ID="lLanguage" runat="server" Text="Language: " CssClass="label1" meta:resourcekey="lLanguageResource1"></asp:Label>
                                <asp:DropDownList ID="ddlanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="language_SelectedIndexChanged" CssClass="dropdown1" meta:resourcekey="ddlanguageResource1">
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

                            <uc1:songNumber runat="server" ID="songNumber" Visible="False" />
                            <uc2:currentList ID="currentList1" runat="server" Visible="False" />
                            <uc3:video runat="server" ID="video" Visible="False" />
                            <uc4:volume runat="server" ID="volume" Visible="False" />
                            <uc5:tune runat="server" ID="tune" Visible="False" />
                            <uc6:advanced runat="server" ID="advanced" Visible="False" />
                            <uc0:find runat="server" ID="find" Visible="False" ClientIDMode="Static" />
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
                                <asp:Button ID="BdRepeat" runat="server" Text="循環" CssClass="button4" OnClick="BdRepeat_Click" meta:resourcekey="BdRepeatResource1" />
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
                                <asp:Button ID="BdMute" runat="server" Text="靜音" CssClass="button4" OnClick="BdMute_Click" meta:resourcekey="BdMuteResource1" />
                                <asp:Button ID="BdVolumeDown" runat="server" Text="-音量" CssClass="button4" OnClick="BdVolumeDown_Click" meta:resourcekey="BdVolumeDownResource1"  />
                                <asp:Button ID="BdColumeUp" runat="server" Text="+音量" CssClass="button4" OnClientClick=";" OnClick="BdColumeUp_Click" meta:resourcekey="BdColumeUpResource1" />
                                <div class="arrowSpacer" style="display: inline-block"></div>
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
