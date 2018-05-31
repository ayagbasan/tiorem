<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="tiorem.editor._default" %>

<%@ Register Src="~/uc/ucArticleSummary.ascx" TagPrefix="uc1" TagName="ucArticleSummary" %>
<%@ Register Src="~/uc/ucArticleDetail.ascx" TagPrefix="uc1" TagName="ucArticleDetail" %>





<asp:Content ID="Content1" ContentPlaceHolderID="sectionHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sectionContent" runat="server">
    <%--<section class="content-header">
        <h1>HABER İŞLEMLERİ
       
            <small>Genel Durum</small>
        </h1>
       
    </section>--%>
    <section class="content">

        <dx:ASPxCallbackPanel ID="cp" ClientInstanceName="cp" OnCallback="cp_Callback" runat="server" Width="100%">
            <PanelCollection>
                <dx:PanelContent>

                    <div class="row">

                        <div class="col-lg-12 col-xs-12">

                            <!-- Map box -->
                            <div class="box box-solid ">
                                <div class="box-header">
                                    <i class="fa fa-map-marker"></i>
                                    <h3 class="box-title">Son İşlem Yapılan 10 Firma</h3>
                                </div>

                                <div class="box-body">

                                    <uc1:ucArticleSummary runat="server" ID="ucArticleSummary" />




                                </div>

                            </div>
                            <!-- /.box -->
                        </div>

                        <div class="col-lg-6 col-xs-12">
                            <uc1:ucArticleDetail runat="server" ID="ucArticleDetail" />
                            <!-- Calendar -->

                        </div>

                    </div>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sectionScript" runat="server">
</asp:Content>
