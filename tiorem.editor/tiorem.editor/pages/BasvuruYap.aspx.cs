using tiorem.editor.business;
using tiorem.editor.database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tiorem.editor.pages
{
    public partial class BasvuruYap : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBasvuruYAP_Click(object sender, EventArgs e)
        {
            litMesaj.Text = "";
            litMesaj.Visible = true;

            PRTMPERS personel = exim.GetSORUMLU();
            string username = exim.GetUsername();
            int sicil = personel.SICIL;


            Tuple<bool, List<PRTUNVAN>> basvuruYaparMi = BusinessBL.GetInstance().BasvuruYapabilirMi((int)personel.UNKOD);


            if (!basvuruYaparMi.Item1)
            {
                StringBuilder sb = new StringBuilder("<ul>");
                foreach (var item in basvuruYaparMi.Item2)
                {
                    if (item.DERECE != null)
                        sb.AppendLine("<li> " + item.UNVAN + " (Derece: " + item.DERECE + ")</li>");
                    else
                        sb.AppendLine("<li> " + item.UNVAN +"</li>");
                }

                sb.AppendLine("</ul>");

                litMesaj.Text += BusinessBL.GetInstance().GetUyariMesaj("Başvuru yapma hakkınız bulunmamaktadır. Başvuru yapabilecek olan unvanlar;" + sb.ToString());

                return;
            }

            // Başvuruları Kaydet
            List<ACIKPOZISYONTALEP> mailGonderilecekTalepler = new List<ACIKPOZISYONTALEP>();
            List<string> messageList = new List<string>();


            if (chkPozisyonlar.SelectedValues.Count > 0)
            {

                foreach (var item in chkPozisyonlar.SelectedValues)
                {
                    Tuple<bool, ACIKPOZISYON, string> ap = BusinessBL.GetInstance().GetAcikPozisyon((int)item);

                    Tuple<bool, ACIKPOZISYONTALEP, string> result = BusinessBL.GetInstance().SetBasvuruTalep(ap.Item2, sicil, username);


                    if (result.Item1)
                    {
                        mailGonderilecekTalepler.Add(result.Item2);
                        messageList.Add(BusinessBL.GetInstance().GetBasariliMesaj(result.Item3));
                    }
                    else
                    {
                        messageList.Add(BusinessBL.GetInstance().GetHataMesaj(result.Item3));
                    }

                }

                foreach (var item in messageList)
                {
                    litMesaj.Text += item;
                }

                if (mailGonderilecekTalepler.Count > 0)
                {
                    //Başarılı Başvuruları Mail Gönder
                    string icerikTemplate = File.ReadAllText(Server.MapPath(BusinessBL.DomainName+ "/assets/mailTemplate/TemplateSuccess.html"));


                    StringBuilder tableRows = new StringBuilder();
                    foreach (var item in mailGonderilecekTalepler)
                    {
                        string rowTemplate = File.ReadAllText(Server.MapPath(BusinessBL.DomainName+ "/assets/mailTemplate/TemplateSuccessList.html"));

                        rowTemplate = rowTemplate.Replace("###DATA_1###", personel.PRTBIRIM.BIRADI);
                        rowTemplate = rowTemplate.Replace("###DATA_2###", personel.ADI + " " + personel.SOYADI);
                        rowTemplate = rowTemplate.Replace("###DATA_3###", item.SICIL.ToString());
                        rowTemplate = rowTemplate.Replace("###DATA_4###", item.ACIKPOZISYON.PRTBIRIM.BIRADI);
                        rowTemplate = rowTemplate.Replace("###DATA_5###", item.EKLZMN.Value.ToString("dd.MM.yyyy HH:mm"));
                        //rowTemplate = rowTemplate.Replace("###DATA_6###", item.ID.ToString());

                        tableRows.AppendLine(rowTemplate);
                    }


                    icerikTemplate = icerikTemplate.Replace("###ICERIK_0###", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                    icerikTemplate = icerikTemplate.Replace("###ICERIK_1###", personel.ADI + " " + personel.SOYADI);
                    icerikTemplate = icerikTemplate.Replace("###ICERIK_2###", tableRows.ToString());


                    Tuple<bool, string> email = BusinessBL.GetInstance().GetEmailAdress(personel.SICIL);
                    if (email.Item1)
                    {
                        BusinessBL.GetInstance().MailGonderici(email.Item2, icerikTemplate);
                        litMesaj.Text += BusinessBL.GetInstance().GetBasariliMesaj("Başvurunuz kayıt edilmiştir. Mail adresinize bildirim gönderilmiştir");
                    }
                    else
                    {
                        litMesaj.Text += BusinessBL.GetInstance().GetUyariMesaj("Başvurunuz kayıt edildi. Mail adresinizi sistem tarafından bulunamadığı için bildirim gönderilemedi");

                    }
                }
            }
            else
            {
                litMesaj.Text += BusinessBL.GetInstance().GetUyariMesaj("Pozisyon seçimi yapınız");
            }

        }


    }
}