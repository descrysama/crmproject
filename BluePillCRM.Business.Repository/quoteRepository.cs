using System;
using BluePillCRM.Datas;
using BluePillCRM.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BluePillCRM.Business.Repository
{
	public class QuoteRepository
	{
        protected readonly BluePillCRMDbContext _bluePillCRMDbContext;

        protected readonly DbSet<Quote> _table;
        public QuoteRepository(BluePillCRMDbContext bluePillCRMDbContext)
        {
            _bluePillCRMDbContext = bluePillCRMDbContext;
            _table = _bluePillCRMDbContext.Set<Quote>();
        }



    }
}

