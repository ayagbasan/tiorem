using tiorem.editor.database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using tiorem.editor.database.repository.Base;

namespace tiorem.editor.business
{
    public class BusinessBL
    {
        static BusinessBL instance; 
        public static BusinessBL GetInstance()
        {
            return instance ?? (new BusinessBL());
        }

 
        public string GetHataMesaj(string mesaj)
        {
            return
            @"<div class='alert alert-danger alert-dismissible'>" +
                "<button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>" +
                "<h4><i class='icon fa fa-ban'></i>HATA</h4>" +
                mesaj +
            "</div>";
        }

        public string GetBasariliMesaj(string mesaj)
        {
            return
            @"<div class='alert alert-success  alert-dismissible'>" +
                "<button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>" +
                "<h4><i class='icon fa fa-check'></i>İŞLEM BAŞARILI</h4>" +
                mesaj +
            "</div>";
        }

        public string GetUyariMesaj(string mesaj)
        {
            return
            @"<div class='alert alert-warning   alert-dismissible'>" +
                "<button type = 'button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>" +
                "<h4><i class='icon fa fa-warning'></i>UYARI</h4>" +
                mesaj +
            "</div>";
        }

        public User GetUser(string username)
        {
            try
            {
                IRepositoryBase<User> repo = new RepositoryBase<User>();
                return repo.Get(p => p.Username == username,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

         
    }
}