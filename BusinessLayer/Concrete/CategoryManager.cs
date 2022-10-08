﻿using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return repo.List();
        }

        public void CategoryAddBL (Category p)
        {
            if(p.CategoryName=="" || p.CategoryName.Length <= 3 || p.CategoryDescription=="" ||
                p.CategoryStatus==false || p.CategoryName.Length >= 50)
            {
                //hata mesajı
            }
            else
            {
                repo.Insert(p);
            }
        }

    }
}