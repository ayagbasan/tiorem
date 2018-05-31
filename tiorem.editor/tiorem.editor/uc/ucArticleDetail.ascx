<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucArticleDetail.ascx.cs" Inherits="tiorem.editor.uc.ucArticleDetail" %>
<asp:FormView ID="frmArticle" runat="server" Width="100%">
    <ItemTemplate>
        <div class="box box-solid">
            <div class="box-header">

                <img src="<%# Eval("CatalogueSource.ImageUrl") %>" width="48" />
                <h3 class="box-title"><%# Eval("Title").ToString().Length>75?Eval("Title").ToString().Substring(0,75)+"...":Eval("Title").ToString() %> </h3>

            </div>

            <div class="box-body">

                
                <div class="row">
                    <div class="col-lg-3">
                        <img src="<%# Eval("ImageUrl") %>" width="200" />

                    </div>
                    <div class="col-lg-9">
                        <%# Eval("Body")%>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-lg-2">
                         Durum
                    </div>
                    <div class="col-lg-2">
                         Onay Tarihi
                    </div>
                    <div class="col-lg-2">
                         Onaylayan
                    </div>
                    <div class="col-lg-6">
                         Tags
                    </div>
                    </div>
                     <div class="row">
                     <div class="col-lg-2">
                         Onaylandı
                    </div>
                    <div class="col-lg-2">
                        31.05.2018 23:47
                    </div>
                    <div class="col-lg-2">
                         admin
                    </div>
                    <div class="col-lg-6">
                         #BeşiktaşTransfer #BeşiktaşTransfer #BeşiktaşTransfer #BeşiktaşTransfer #BeşiktaşTransfer
                    </div>
                </div>
            </div>
        </div>

        </div>


    </ItemTemplate>
</asp:FormView>

<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=TIOREMEntities" DefaultContainerName="TIOREMEntities" EnableFlattening="False" EntitySetName="Article">
</asp:EntityDataSource>


