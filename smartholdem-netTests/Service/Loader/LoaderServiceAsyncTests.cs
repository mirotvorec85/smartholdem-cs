﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHoldemNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHoldemNet.Utils.Enum;

namespace SmartHoldemNet.Service.Loader.Tests
{
    [TestClass()]
    public class LoaderServiceAsyncTests : LoaderServiceTestsBase
    {
        [TestInitialize]
        public async Task Init()
        {
            await base.InitializeAsync();
        }

        [TestMethod()]
        public async Task GetStatusAsyncTest()
        {
            var status = await LoaderService.GetStatusAsync();

            GetStatusResultTest(status);
        }

        [TestMethod()]
        public async Task GetSyncStatusAsyncTest()
        {
            var syncStatus = await LoaderService.GetSyncStatusAsync();

            GetSyncStatusResultTest(syncStatus);
        }

        [TestMethod()]
        public async Task GetAutoConfigureParametersAsyncTest()
        {
            var parameters = await LoaderService.GetAutoConfigureParametersAsync();

            GetAutoConfigureParametersResultTest(parameters);
        }
    }
}