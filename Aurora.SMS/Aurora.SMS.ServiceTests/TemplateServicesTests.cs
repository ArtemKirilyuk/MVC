﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.SMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.SMS.Service.Data;
using Moq;
using Aurora.Core.Data;
using Aurora.SMS.ServiceTests;
using System.Data.Entity;
using Aurora.SMS.EFModel;

namespace Aurora.SMS.Service.Tests
{
    [TestClass()]
    public class TemplateServicesTests
    {
        [TestMethod()]
        public void UpdateTestWhenTemplateHasReference()
        {
            var  faker = new Bogus.Faker();
            int mockTemplateId = faker.Random.Number();
            var mockContext = new Mock<SMSDb>();


            var smsHistoryList = new List<SMSHistory>
            {
               FixtureGenerator.CreateSMSHistory(mockTemplateId)
            };
            var mockSMSHistorySet = EFHelper.GetQueryableMockDbSet(smsHistoryList);
            mockContext.Setup(c => c.SMSHistoryRecords).Returns(mockSMSHistorySet.Object);

            // Set the template
            var templateList = new List<Template>();
            var mockTemplateSet = EFHelper.GetQueryableMockDbSet(templateList);
            //I need to set the Set<Template> Template  
            // because the line dbSet = DbContext.Set<T>(); on the Generic repository fails
            mockContext.Setup(m => m.Set<Template>()).Returns(mockTemplateSet.Object);
            mockContext.Setup(c => c.Templates).Returns(mockTemplateSet.Object);

            var mockICurrentUserService = new Mock<ICurrentUserService>();
            mockICurrentUserService.Setup(p => p.GetCurrentUser()).Returns("TestUser");
            // Mocking up dbFactory
            var mockdbFactory = new Mock<DbFactory<SMSDb>>();
            mockdbFactory.Setup(m => m.DBContext).Returns(mockContext.Object);
            IUnitOfWork<SMSDb> UoW = new UnitOfWork<SMSDb>(mockdbFactory.Object, mockICurrentUserService.Object);

            var target = new TemplateServices(mockdbFactory.Object);
            target.Update(new EFModel.Template() { Id= mockTemplateId });

            Assert.IsTrue(mockContext.Object.Templates.Any());




        }
    }
}