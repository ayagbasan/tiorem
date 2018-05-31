<%@ Page Title="" Language="C#" MasterPageFile="~/exim.Master" AutoEventWireup="true" CodeBehind="BasvuruYap.aspx.cs" Inherits="tiorem.editor.pages.BasvuruYap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="sectionHeader" runat="server">
    <title>Boş Pozisyonlar</title>

    <script type="text/javascript">
        function Validate(s, e) {
            e.processOnServer = confirm("Başvuru talebiniz kayıt edilecektir. Onaylıyor musunuz?");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sectionContent" runat="server">

    <section class="content container-fluid">

        <asp:EntityDataSource ID="edsBirimler" runat="server" ConnectionString="name=ModelEntities" DefaultContainerName="ModelEntities" EnableFlattening="False" EntitySetName="PRTBIRIM" OrderBy="it.BIRADI" Where="it.ACTIVE==true" Select="it.[BIRKOD], it.[BIRADI], it.[ACTIVE]"></asp:EntityDataSource>
        <asp:EntityDataSource ID="edsVWAcikPozisyon" runat="server" ConnectionString="name=ModelEntities" DefaultContainerName="ModelEntities"
            EnableFlattening="False" EntitySetName="VW_ACIKPOZISYON" OrderBy="it.ID DESC" Where="it.AKTIF==true">
        </asp:EntityDataSource>


        <asp:Literal ID="litMesaj" runat="server"></asp:Literal>





        <div class="col-md-8">

            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">BANKA İÇİ AÇIK POZİSYON BAŞVURU İŞLEMLERİ</h3>
                </div>
                <div class="box-body pad">
                    <h4 style="line-height: 30px">Bankamız Şubeleri ve İrtibat Bürolarında pazarlama alanında görevlendirilmek üzere   
                        <u> uzman/uzman yardımcısı</u> ve <u>yetkili/yetkili yardımcısı</u> personel ihtiyacı bulunmaktadır.
                    </h4>
                    <h4>Aşağıda belirtilen şube ve irtibat bürolarında görevlendirilmek üzere başvuru yapabilirsiniz.</h4>
                    <h4><b>İnsan Kaynakları</b></h4>
                </div>
            </div>

        </div>

        <div class="col-md-8">

            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">PAZARLAMA ALANINDA AÇIK POZİSYONU OLAN BİRİMLER</h3>
                </div>
                <div class="box-body pad">

                    <dx:ASPxCheckBoxList ID="chkPozisyonlar" runat="server" DataSourceID="edsVWAcikPozisyon" TextField="BIRADI" ValueField="ID" ValueType="System.Int32">
                    </dx:ASPxCheckBoxList>

                </div>
            </div>

        </div>

        <div class="col-md-8">

            <div class="box box-primary">
                <div class="box-body pad" style="text-align: center">
                    <dx:ASPxButton ID="btnBasvuruYAP" runat="server" Text="BAŞVURU YAP" OnClick="btnBasvuruYAP_Click" AutoPostBack="true">
                    </dx:ASPxButton>
                </div>
            </div>

        </div>

    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sectionScript" runat="server">
</asp:Content>
