<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web._default" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="~/songNumber.ascx" TagPrefix="uc1" TagName="songNumber" %>
<%@ Register src="~/currentList.ascx" tagname="currentList" tagprefix="uc2" %>
<%@ Register Src="~/video.ascx" TagPrefix="uc3" TagName="video" %>
<%@ Register Src="~/volume.ascx" TagPrefix="uc4" TagName="volume" %>
<%@ Register Src="~/find.ascx" TagPrefix="uc0" TagName="find" %>
<%@ Register Src="~/tune.ascx" TagPrefix="uc5" TagName="tune" %>
<%@ Register Src="~/advanced.ascx" TagPrefix="uc6" TagName="advanced" %>










<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <script src="jquery.blockUI.js"></script>
    <meta charset="utf-8" />
    <title>KTV</title>
</head>
<body dir='<asp:Literal ID="Literal1" runat="server" Text="<%$Resources: GlobalMessages, directionltr %>"></asp:Literal>'>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableHistory="True">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <header id="masterheader">
                    <section>
                        <asp:Label ID="LComputerOnlyMessage" runat="server" Text="'F11' on the keyboard to activate/diactivate full screen." meta:resourcekey="LComputerOnlyMessageResource1"></asp:Label>
                    </section>
                    <nav> 
                        <div style="display:block">
                        <div style="float: left; width: 50%; display:block">                           
                            <asp:Label ID="lFunctions" runat="server" Text="Functions: " meta:resourcekey="lFunctionsResource1" CssClass="label1" ></asp:Label>
                            <asp:DropDownList ID="ddActions" runat="server" AutoPostBack="True" CssClass="dropdown1" meta:resourcekey="ddActionsResource1" OnSelectedIndexChanged="ddActions_SelectedIndexChanged">
                            <asp:ListItem meta:resourcekey="ListItemResource30" Text="---------"></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource20" Text="Find"></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource21" Text="Song Number"></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource22" Text="Waiting List"></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource23" Text="Video"></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource24" Text="Volume"></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource25" Text="Tune"></asp:ListItem>
                            <asp:ListItem meta:resourcekey="ListItemResource26" Text="Advanced"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                            <div style="float: right; width: 50%; display:block">
                            <asp:Label ID="lLanguage" runat="server" Text="Language: " CssClass="label1" meta:resourcekey="lLanguageResource1"></asp:Label>
                            <asp:DropDownList ID="ddlanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="language_SelectedIndexChanged" CssClass="dropdown1" meta:resourcekey="ddlanguageResource1">
                                <asp:ListItem Value="en-US" Text="English" meta:resourcekey="ListItemResource14"></asp:ListItem>
                                <asp:ListItem Value="zh-CHT" Text="繁體中文" meta:resourcekey="ListItemResource15"></asp:ListItem>
                                <asp:ListItem Value="zh-CHS" Text="简体中文" meta:resourcekey="ListItemResource16"></asp:ListItem>
                                <asp:ListItem Value="ja-JP" Text="日本語" meta:resourcekey="ListItemResource17"></asp:ListItem>
                                <asp:ListItem Value="ko-KR" Text="한국의" meta:resourcekey="ListItemResource18"></asp:ListItem>
                                <asp:ListItem Value="th-TH" Text="ภาษาไทย" meta:resourcekey="ListItemResource19"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                      </div>
                    </nav>
                </header>

                   
                <article id="mainarea">
                    <section>
                        <div>
                           
                            <uc0:find runat="server" id="find"  Visible="False"/>
                            <uc1:songNumber runat="server" ID="songNumber" Visible="False" />
                            <uc2:currentList ID="currentList1" runat="server" />
                            <uc3:video runat="server" ID="video" Visible="False" />
                            <uc4:volume runat="server" ID="volume" Visible="False" />
                            <uc5:tune runat="server" id="tune"  Visible="False"/>
                            <uc6:advanced runat="server" ID="advanced" />
                        </div>
                    </section>                    
                </article>


                       
      <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay" />
            <div class="overlayContent" id="overlayContent1">
                <h2>
                    <asp:Label ID="lLoading" runat="server" Text="Loading..."></asp:Label></h2>
                <img src="/images/ajax-loader.gif" alt="Loading"/>
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
