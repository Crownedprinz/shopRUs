using AutoMapper;
using shopRUs.Models.Invoices;
using shopRUs.Models.Invoices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Helper
{
    public class MapHelper: Profile
    {
            public MapHelper()
            {
                CreateMap<Tbl_Invoices, CreateInvoiceDto>();
                CreateMap<CreateInvoiceDto, Tbl_Invoices>();
            }
        
    }
}
