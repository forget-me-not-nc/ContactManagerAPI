using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using BLL.DTOs.ImportDTOs;
using BLL.Services.ContactInfoServices;
using BLL.DTOs.ContacInfoDTOs;
using AutoMapper;

namespace BLL.Services.ImportServices
{
    public class CSVImporter : ICSVImporter
    {
        private readonly IContactInfoService _contactInfoService;
        private readonly IMapper _mapper;

        public CSVImporter(
            IContactInfoService contactInfoService,
            IMapper mapper)
        {
            _contactInfoService = contactInfoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactResponse>> Import(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    using (var streamReader = new StreamReader(file.OpenReadStream()))
                    using (var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        var records = csvReader.GetRecords<CSVImportDTO>().ToList().Select(el => _mapper.Map<CreateContactRequest>(el));

                        return await _contactInfoService.CreateRangeAsync(records);
                    }
                }
                else throw new Exception("Invalid file!");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
