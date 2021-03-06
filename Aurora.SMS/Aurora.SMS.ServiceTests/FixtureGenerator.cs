﻿using Aurora.Insurance.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.SMS.ServiceTests
{
    /// <summary>
    /// Generates EF objects with the help of the Bogus.Faker
    /// </summary>
    public static class FixtureGenerator
    {
        private static Bogus.Faker faker = new Bogus.Faker();
        public static EFModel.SMSHistory CreateSMSHistory(int templateId = 0)
        {
            return new EFModel.SMSHistory()
            {
                Message = faker.Lorem.Sentence(),
                MobileNumber = faker.Phone.PhoneNumber(),
                ProviderName = faker.Lorem.Word(),
                ProviderFeedback = faker.Lorem.Sentence(),
                TemplateId = templateId
            };
        }

        public static ICollection<EFModel.TemplateField> CreateTemplateFields()
        {
            return new List<EFModel.TemplateField>
            {
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="ContractNumber",
                    Description="The number of the contract"
                },
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="ReceiptNumber",
                    Description="The number of the receipt"
                },
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="IssueDate",
                    Description="The Issue Date",
                    DataFormat="dd/MM/yyyy"

                },
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="StartDate",
                    Description="The Start Date",
                    DataFormat="dd/MM/yyyy"
                },
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="ExpireDate",
                    Description="The Expire Date",
                    DataFormat="dd/MM/yyyy"
                },
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="GrossAmount",
                    Description="The GrossAmount",
                    DataFormat="0.00"
                },
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="NetAmount",
                    Description="The NetAmount",
                    DataFormat="0.00"
                },
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="TaxAmount",
                    Description="The TaxAmount",
                    DataFormat="0.00"
                },


                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="PlateNumber",
                    Description="The PlateNumber"
                },
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="CanceledDate",
                    Description="The CanceledDate",
                    DataFormat="dd/MM/yyyy"
                },
                new EFModel.TemplateField
                {
                    GroupName="Contract",
                    Name="CompanyDescription",
                    Description="The CompanyDescription"
                },
                new EFModel.TemplateField
                {
                    GroupName="Person",
                    Name="FirstName",
                    Description="The FirstName"
                },
                new EFModel.TemplateField
                {
                    GroupName="Person",
                    Name="LastName",
                    Description="The LastName"
                },
                new EFModel.TemplateField
                {
                    GroupName="Person",
                    Name="DrivingLicenceNum",
                    Description="The LastName"
                },
                new EFModel.TemplateField
                {
                    GroupName="Person",
                    Name="TaxId",
                    Description="The LastName"
                },
                new EFModel.TemplateField
                {
                    GroupName="Person",
                    Name="Address",
                    Description="The LastName"
                },
                new EFModel.TemplateField
                {
                    GroupName="Person",
                    Name="ZipCode",
                    Description="The LastName"
                },
                new EFModel.TemplateField
                {
                    GroupName="Person",
                    Name="BirthDate",
                    Description="The LastName",
                    DataFormat="dd/MM/yyyy"
                }

            };
        }

        public static ICollection<ContractDTO> CreateSMSRecepients(int elements = 2)
        {
            var lst = new List<ContractDTO>();
            for (var i = 0; i < elements; i++)
            {
                Bogus.Faker faker = new Bogus.Faker();
                var mockPerson = new Bogus.Person();
                var gross = faker.Random.Number(100, 1000);
                var tax = (decimal)((double)gross * (10d / 100d));
                lst.Add(new ContractDTO()
                {
                    Address = mockPerson.Address.Street,
                    BirthDate = mockPerson.DateOfBirth,
                    DrivingLicenceNum = faker.Lorem.Letter().ToUpper() + faker.Lorem.Letter().ToUpper() + "-" + faker.Random.UInt(10000, 99999).ToString(),
                    FatherName = faker.Name.FirstName(),
                    FirstName = mockPerson.FirstName,
                    LastName = mockPerson.LastName,
                    TaxId = faker.Random.UInt(1000000, 9999999).ToString(),
                    ZipCode = mockPerson.Address.ZipCode,
                    CompanyDescription = faker.Company.CompanyName(),
                    CompanyId = faker.Random.UShort().ToString(),
                    ContractNumber = faker.Random.Number(1000000, 9999999).ToString(),
                    IssueDate = DateTime.Today,
                    ExpireDate = DateTime.Today.AddMonths(6),
                    GrossAmount = gross,
                    TaxAmount = tax,
                    NetAmount = gross - tax,
                    PlateNumber = faker.Lorem.Letter().ToUpper() +
                                        faker.Lorem.Letter().ToUpper() +
                                        faker.Lorem.Letter().ToUpper() +
                                        "-" +
                                        faker.Random.UInt(10000, 99999).ToString(),
                    ReceiptNumber = faker.Random.Number(10000000, 99999999).ToString(),
                    StartDate = DateTime.Today,
                    MobileNumber = faker.Phone.PhoneNumber()
                });
            }
            return lst;
        }


    }
}
