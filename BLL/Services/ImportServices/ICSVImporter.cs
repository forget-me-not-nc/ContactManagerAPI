using BLL.DTOs.ContacInfoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.ImportServices
{
    public interface ICSVImporter: IImporter<ContactResponse>
    {
    }
}
