<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucArticleSummary.ascx.cs" Inherits="tiorem.editor.uc.ucArticleSummary" %>

<%--<asp:EntityDataSource ID="efArticleSummary" runat="server" ConnectionString="name=TIOREMEntities" DefaultContainerName="TIOREMEntities" EnableFlattening="False" EntitySetName="VW_ARTICLE_SUMMARY"  Where="it.InsertedAt&gt;@Tarih">
     <WhereParameters>
    <asp:Parameter   DbType="Date"  Name="Tarih"  />
  </WhereParameters>
</asp:EntityDataSource>--%>
<%--DataSourceID="efArticleSummary"--%>

<script>

    function getDetails(s,e) {
        if (e.buttonID == 'btnDetay') {
            var rowKey = s.GetRowKey(e.visibleIndex);
            cp.PerformCallback("GetArticleDetails:" + rowKey);           
        }
    }

</script>

<dx:ASPxGridView ID="gridArticleSummary" runat="server" AutoGenerateColumns="False"   KeyFieldName="Id" Width="100%" OnInit="gridArticleSummary_Init">
    <ClientSideEvents CustomButtonClick="function(s, e) {
	getDetails(s,e);
}" />
    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
    <SettingsSearchPanel ColumnNames="Title" Visible="True" />
    <Columns>
        <dx:GridViewDataTextColumn Caption="Haber Id" FieldName="Id" ReadOnly="True" VisibleIndex="0" Width="50px">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Kaynak" FieldName="SourceName" ReadOnly="True" VisibleIndex="1" Width="75px">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="SourceId" ReadOnly="True" Visible="False" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="CategoryId" ReadOnly="True" Visible="False" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Kategori" FieldName="CategoryName" ReadOnly="True" VisibleIndex="4" Width="75px">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn Caption="Yayın Tarihi" FieldName="PubDate" VisibleIndex="10" Width="85px">
            <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy HH:mm">
            </PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataCheckColumn Caption="Aktif" FieldName="Active" ReadOnly="True" Visible="False" VisibleIndex="6" Width="40px">
        </dx:GridViewDataCheckColumn>
        <dx:GridViewDataCheckColumn Caption="Onay" FieldName="Approved" ReadOnly="True" VisibleIndex="7" Width="40px">
        </dx:GridViewDataCheckColumn>
        <dx:GridViewDataTextColumn FieldName="ApprovedUserId" Visible="False" VisibleIndex="8">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn Caption="Kayıt Tarihi" FieldName="InsertedAt" ReadOnly="True" VisibleIndex="9" Width="85px">
            <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy HH:mm">
            </PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataDateColumn Caption="Onay Tarihi" FieldName="ApprovedAt" VisibleIndex="11" Width="85px">
            <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy HH:mm">
            </PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataTextColumn Caption="Onaylayan" FieldName="Username" ReadOnly="True" VisibleIndex="12" Width="50px">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Başlık" FieldName="Title" VisibleIndex="5">
            <PropertiesTextEdit DisplayFormatString="{0}">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewCommandColumn ButtonRenderMode="Button" ButtonType="Button" Caption="Detaylar" VisibleIndex="13" Width="50px">
            <CustomButtons>
                <dx:GridViewCommandColumnCustomButton ID="btnDetay" Text="Detaylar">
                </dx:GridViewCommandColumnCustomButton>
            </CustomButtons>
        </dx:GridViewCommandColumn>
    </Columns>
</dx:ASPxGridView>


